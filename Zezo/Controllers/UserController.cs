using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
//using Zezo.Models;
using Zezo.ViewModel;

namespace Zezo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanger;
        private readonly IConfiguration _configuration;

        public UserController(/*rsc_v2Context context,*/ UserManager<IdentityUser> usermanger, RoleManager<IdentityRole> rolemanger, IConfiguration configuration)
        {
            _userManager = usermanger;
            _rolemanger = rolemanger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.UserName) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var user = await _userManager.FindByNameAsync(loginModel.UserName);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!isPasswordValid)
            {
                return Unauthorized("Invalid username or password.");
            }

            var authclaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),

                new Claim(ClaimTypes.NameIdentifier, user.Id), // Add NameIdentifier claim

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authclaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = GetToken(authclaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                message = "well done pro login successfuly",
                roles = userRoles  // Add roles to the response
            }) ;
        }


  
        private JwtSecurityToken GetToken(List<Claim> authclaims)
        {
            var authsigningkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
           
            var token = new JwtSecurityToken(
                 
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(20),
                claims: authclaims,
                signingCredentials: new SigningCredentials(authsigningkey, SecurityAlgorithms.HmacSha256)

                );
            return token;
        }




      
         
         


        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] LoginModel loginmodel)
        //{
        //    if (loginmodel == null || string.IsNullOrEmpty(loginmodel.UserName) || string.IsNullOrEmpty(loginmodel.Password))
        //    {
        //        return BadRequest("Username and password are required.");
        //    }

        //    var user = await _usermanger.FindByNameAsync(loginmodel.UserName);

        //    if (user == null)
        //    {
        //        return BadRequest("User Name Not Found ");
        //    }

        //    if (user != null && await _usermanger.CheckPasswordAsync(user, loginmodel.Password))
        //    {


        //        var authclaims = new List<Claim>

        //        {
        //        new Claim(ClaimTypes.Name,user.UserName),
        //        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //        };

        //        var userRoles = await _usermanger.GetRolesAsync(user);

        //        foreach (var role in userRoles)
        //        {
        //            authclaims.Add(new Claim(ClaimTypes.Role, role));
        //        }

        //        var Jwttoken = GetToken(authclaims);

        //        return Ok(new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(Jwttoken),
        //            expiration = Jwttoken.ValidTo
        //        });
        //    }

        //    return Unauthorized("Username or password is invalid.");
        //}




        //private JwtSecurityToken GetToken(List<Claim> authclaims)
        //{
        //    var authsigningkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JWT:Issuer"],
        //        audience: _configuration["JWT:Audience"],
        //        expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_configuration.GetValue<int>("JWT:DurationInDays"))),
        //        claims: authclaims,
        //        signingCredentials: new SigningCredentials(authsigningkey, SecurityAlgorithms.HmacSha256)
        //    );
        //    return token;
        //}

    }
}
