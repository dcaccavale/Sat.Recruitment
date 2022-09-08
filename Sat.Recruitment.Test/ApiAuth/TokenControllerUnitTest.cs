
using JWTAuth.WebApi.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sat.Recruitment.ApiAuth.ModelAuth;
using Sat.Recruitment.Test.Helpers;
using System.Text;
using Xunit;

namespace Sat.Recruitment.Test.ApiAuth
{
    [CollectionDefinition("TokenControllerUnitTest", DisableParallelization = true)]
    public class TokenControllerUnitTest
    {

        private readonly TokenController _tokenController;

        public TokenControllerUnitTest()
        {

            var builder = WebApplication.CreateBuilder();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.Conventions.Controller<JWTAuth.WebApi.Controllers.TokenController>().HasApiVersion(new ApiVersion(1, 0));
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            var pp = builder.Build();
             _tokenController = new TokenController(pp.Configuration);

         
        }

        [Fact]
        public async void TokenController_Post_Token_200OK()
        {
            UserInfo user = new UserInfo
            {
                UserName = "test",
                Password = "123",
                Email = "user",
                DisplayName ="USer"
               
            };
            var response = await _tokenController.Post(user);
            var okResult = response as ObjectResult;
            Assert.NotNull(okResult);
            Assert.NotEmpty(okResult.Value.ToString());
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async void TokenController_Post_Token_BadRequest_EmailAndPasswordAreRequired()
        {
            UserInfo user = new UserInfo
            {
                UserName = "User",
                Password = "",
                Email = "",
                DisplayName = "USer MEMO"

            };
            var response = await _tokenController.Post(user);
            var okResult = response as BadRequestResult;
            Assert.NotNull(response);
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);

        }

        [Fact]
        public async void TokenController_Post_Token_BadRequest_FailAuth()
        {
            UserInfo user = new UserInfo
            {
                UserName = "",
                Password = "not",
                Email = "not",
                DisplayName = "USer MEMO"

            };
            var response = await _tokenController.Post(user);
            var okResult = response as BadRequestObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);

        }

    }
}
