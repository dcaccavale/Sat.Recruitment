using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sat.Recruitment.ApiAuth.ModelAuth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuth.WebApi.Controllers
{

    [Route("v{version:apiVersion}/api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
      
        public TokenController(IConfiguration config)
        {
            _configuration = config;
           
        }


        [HttpPost]
        public async Task<IActionResult> Post(UserInfo _userData)
        {
            if (_userData != null && !string.IsNullOrWhiteSpace(_userData.Email) && !string.IsNullOrWhiteSpace(_userData.Password))
            {
                var user = GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //TODO Use to repository to look for user, this implementation if only for a demostration
        // To Do add repository , context and serviceModel to access to data user store in data base
        private UserInfo? GetUser(string email, string password)
        {

            if (email == "user" && password == "123") {
                return new UserInfo()
                {
                    DisplayName = "User",
                    Email = "user",
                    Password = "123",
                    UserName = "User",
                    UserId = 1,
                    CreatedDate = DateTime.Now

                };
            }
            return null;
        }
    }
}