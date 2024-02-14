using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Zezo.ApplicationIdntity
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            SeedUser(builder);
        }

        protected static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
               
                (
                  new IdentityRole() { Id = "1", Name = "user", ConcurrencyStamp = "1", NormalizedName = "user" },

                  new IdentityRole() { Id = "2", Name = "admin", ConcurrencyStamp = "2", NormalizedName = "admin" },

                  new IdentityRole() { Id = "3", Name = "teamleader", ConcurrencyStamp = "3", NormalizedName = "teamleader" },

                  new IdentityRole() { Id = "4", Name = "manger", ConcurrencyStamp = "3", NormalizedName = "manger" },

                  new IdentityRole() { Id = "5", Name = "bigmanger", ConcurrencyStamp = "3", NormalizedName = "bigmanger" }
            
                  );

            builder.Entity<IdentityUserRole<string>>().HasData(


                new IdentityUserRole<string>() { RoleId = "1", UserId = "1" },
                new IdentityUserRole<string>() { RoleId = "2", UserId = "2" },
                new IdentityUserRole<string>() { RoleId = "3", UserId = "3" },
                new IdentityUserRole<string>() { RoleId = "4", UserId = "4" },
                new IdentityUserRole<string>() { RoleId = "5", UserId = "5" });
                
        }

        protected static void SeedUser(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1",
                    UserName = "Kamel",
                    NormalizedUserName = "KAMEL",
                    Email = "kamel@gmail.com",
                    NormalizedEmail = "KAMEL@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Z_kamel_12345")
                },
                new IdentityUser
                {
                    Id = "2",
                    UserName = "Lara",
                    NormalizedUserName = "Lara",
                    Email = "Lara@gmail.com",
                    NormalizedEmail = "Lara@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Z_lara_123456")
                },
                new IdentityUser
                {
                    Id = "3",
                    UserName = "islam",
                    NormalizedUserName = "islam",
                    Email = "islam@gmail.com",
                    NormalizedEmail = "islam@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Z_islam_1234567")
                },
                  new IdentityUser
                  {
                      Id = "4",
                      UserName = "caphatem",
                      NormalizedUserName = "caphatem",
                      Email = "caphatem@gmail.com",
                      NormalizedEmail = "caphatem@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,"hatem_123456")
                  },
                    new IdentityUser
                    {
                        Id = "5",
                        UserName = "capbasuoni",
                        NormalizedUserName = "capbasuoni",
                        Email = "capbasuoni@gmail.com",
                        NormalizedEmail = "capbasuoni@GMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "bas_1234567")
                    }


            );
        }



    }
}