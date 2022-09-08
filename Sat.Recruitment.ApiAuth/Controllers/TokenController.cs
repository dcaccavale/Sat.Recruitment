using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sat.Recruitment.ApiAuth.DataAccess;
using Sat.Recruitment.ApiAuth.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Text;
namespace Sat.Recruitment.ApiAuth.Controllers
{

    [Route("v{version:apiVersion}/api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public ApiAuthContext _apiAuthContext;
        public ILogger<UserInfoRequest> _logger;
       

        public TokenController(IConfiguration config, ApiAuthContext apiAuthContext, ILogger<UserInfoRequest> logger)
        {
            _configuration = config;
            _apiAuthContext = apiAuthContext;
            _logger = logger;   
        }


        [HttpPost]
        public async Task<IActionResult> Post(UserInfoRequest _userData)
        {
            UserInfoRequestValidate userValidate = new UserInfoRequestValidate();
            var validatorResult = userValidate.Validate(_userData);

            if (validatorResult.IsValid)
            {
                var user = GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.IdGuid.ToString()),
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
                    _logger.LogInformation("Token Created");
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    _logger.LogWarning("Invalid credentials");
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
               var  messagge = validatorResult.ToString(" - ");
                _logger.LogWarning(messagge);
                return BadRequest(messagge);
            }
        }
        private UserInfo? GetUser(string email, string password)
        {
            return _apiAuthContext.UserInfo.FirstOrDefault(user => user.Email == email && user.Password == password); 
           
        }
    }
}