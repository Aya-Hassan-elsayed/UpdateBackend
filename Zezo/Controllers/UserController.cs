using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zezo.Models;
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

        public UserController(rsc_v2Context context, UserManager<IdentityUser> usermanger, RoleManager<IdentityRole> rolemanger, IConfiguration configuration)
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

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = GenerateJwtToken(claims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        private JwtSecurityToken GenerateJwtToken(IEnumerable<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationInMinutes = Convert.ToDouble(jwtSettings["DurationInMinutes"]);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationInMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
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
