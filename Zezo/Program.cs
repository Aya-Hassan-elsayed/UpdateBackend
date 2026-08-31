using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OfficeOpenXml;
using System.Text;
using Zezo.ApplicationIdntity;
using Zezo.Controllers;
using Zezo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// =====================================================
// Identity
// =====================================================

builder.Services
.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// =====================================================
// Identity Password Settings
// =====================================================

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;


// مهم: نخليها false عشان hatem_123456 يشتغل
options.Password.RequireUppercase = false;

    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;


});

// =====================================================
// rsc_v2 Database
// Connection موجود داخل rsc_v2Context
// =====================================================

builder.Services.AddDbContext<rsc_v2Context>();

// =====================================================
// Identity Database - Neon PostgreSQL
// =====================================================

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(
opts => opts.TokenLifespan = TimeSpan.FromHours(10)
);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<UserController>();

ExcelPackage.LicenseContext = LicenseContext.Commercial;

// =====================================================
// JWT
// =====================================================

builder.Services
.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    JwtBearerDefaults.AuthenticationScheme;


    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var configuration = builder.Configuration;

    options.SaveToken = true;

    options.RequireHttpsMetadata = false;

    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,

            ValidAudience =
                configuration["JWT:Audience"],

            ValidIssuer =
                configuration["JWT:Issuer"],

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        configuration["JWT:Key"]!
                    )
                )
        };
});

// =====================================================
// CORS
// =====================================================

builder.Services.AddCors(options =>
{
    options.AddPolicy(
    "MyAllowSpecificOrigins",
    policy =>
    {
        policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
    });
});

// =====================================================
// Swagger
// =====================================================

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
    "v1",
    new OpenApiInfo
    {
        Title = "zezo",
        Version = "v1"
    });


c.AddSecurityDefinition(
    "Bearer",
    new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
        {
            new OpenApiSecurityScheme
            {
                Reference =
                    new OpenApiReference
                    {
                        Type =
                            ReferenceType.SecurityScheme,

                        Id = "Bearer"
                    }
            },

            Array.Empty<string>()
        }
        });


});

var app = builder.Build();

// =====================================================
// Swagger
// =====================================================

app.UseSwagger();

app.UseSwaggerUI();

// =====================================================
// Middleware
// =====================================================

app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// =====================================================
// USERS + ROLES
// =====================================================

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;


var userManager =
    services.GetRequiredService<UserManager<IdentityUser>>();

    var roleManager =
        services.GetRequiredService<RoleManager<IdentityRole>>();


    // =================================================
    // Roles
    // =================================================

    var roles = new[]
    {
    "user",
    "admin",
    "teamleader",
    "manger",
    "bigmanger"
};


    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            var result =
                await roleManager.CreateAsync(
                    new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),

                        Name = role,

                        NormalizedName = role.ToUpper()
                    });


            if (!result.Succeeded)
            {
                throw new Exception(
                    $"Could not create role {role}: " +
                    string.Join(
                        ", ",
                        result.Errors.Select(
                            e => e.Description)
                    )
                );
            }
        }
    }


    // =================================================
    // DELETE ONLY OLD caphatem
    // =================================================

    var oldCaphatem =
        await userManager.FindByNameAsync("caphatem");


    if (oldCaphatem != null)
    {
        var deleteResult =
            await userManager.DeleteAsync(oldCaphatem);


        if (!deleteResult.Succeeded)
        {
            throw new Exception(
                "Could not delete old caphatem: " +
                string.Join(
                    ", ",
                    deleteResult.Errors.Select(
                        e => e.Description)
                )
            );
        }
    }


    // =================================================
    // Users
    // =================================================

    var users = new[]
    {
    new
    {
        UserName = "Kamel",
        Email = "kamel@gmail.com",
        Password = "Z_kamel_12345",
        Role = "user"
    },

    new
    {
        UserName = "Lara",
        Email = "Lara@gmail.com",
        Password = "Z_lara_123456",
        Role = "admin"
    },

    new
    {
        UserName = "islam",
        Email = "islam@gmail.com",
        Password = "Z_islam_1234567",
        Role = "teamleader"
    },

    new
    {
        UserName = "caphatem",
        Email = "caphatem@gmail.com",
        Password = "hatem_123456",
        Role = "manger"
    },

    new
    {
        UserName = "capbasuoni",
        Email = "capbasuoni@gmail.com",
        Password = "bas_1234567",
        Role = "bigmanger"
    }
};


    // =================================================
    // CREATE USERS
    // =================================================

    foreach (var item in users)
    {
        var user =
            await userManager.FindByNameAsync(item.UserName);


        // ---------------------------------------------
        // User doesn't exist -> create
        // ---------------------------------------------

        if (user == null)
        {
            user = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),

                UserName = item.UserName,

                NormalizedUserName =
                    item.UserName.ToUpper(),

                Email = item.Email,

                NormalizedEmail =
                    item.Email.ToUpper(),

                EmailConfirmed = true
            };


            var createResult =
                await userManager.CreateAsync(
                    user,
                    item.Password
                );


            if (!createResult.Succeeded)
            {
                throw new Exception(
                    $"Could not create user {item.UserName}: " +
                    string.Join(
                        ", ",
                        createResult.Errors.Select(
                            e => e.Description)
                    )
                );
            }
        }


        // ---------------------------------------------
        // Add role if user doesn't have it
        // ---------------------------------------------

        if (!await userManager.IsInRoleAsync(
                user,
                item.Role))
        {
            var roleResult =
                await userManager.AddToRoleAsync(
                    user,
                    item.Role
                );


            if (!roleResult.Succeeded)
            {
                throw new Exception(
                    $"Could not add role {item.Role} " +
                    $"to user {item.UserName}: " +
                    string.Join(
                        ", ",
                        roleResult.Errors.Select(
                            e => e.Description)
                    )
                );
            }
        }
    }


}

app.Run();
