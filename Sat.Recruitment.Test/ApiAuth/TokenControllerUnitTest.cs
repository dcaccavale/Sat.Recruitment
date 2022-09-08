using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Sat.Recruitment.ApiAuth;
using Sat.Recruitment.ApiAuth.Controllers;
using Sat.Recruitment.ApiAuth.DataAccess;
using Sat.Recruitment.ApiAuth.Extensions;
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
                options.Conventions.Controller<TokenController>().HasApiVersion(new ApiVersion(1, 0));
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            builder.Services.AddDatabaseService();
            builder.Services.AddLogging();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<UserInfoRequest>>();
            var app = builder.Build();
            var context = serviceProvider.GetService<ApiAuthContext>();
            DbInitializer.Initialize(serviceProvider);
            _tokenController = new TokenController(app.Configuration, context,logger );



        }

        [Fact]
        public async void TokenController_Post_Token_200OK()
        {
            UserInfoRequest user = new UserInfoRequest
            {
                Password = "123",
                Email = "user@user",
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
            UserInfoRequest user = new UserInfoRequest
            {
                Password = "",
                Email = ""

            };
            var response = await _tokenController.Post(user);
            var okResult = response as BadRequestObjectResult;
            Assert.NotNull(response);
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);

        }

        [Fact]
        public async void TokenController_Post_Token_BadRequest_FailAuth()
        {
            UserInfoRequest user = new UserInfoRequest
            {
                Password = "not",
                Email = "user",
            };
            var response = await _tokenController.Post(user);
            var okResult = response as BadRequestObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);

        }

    }
}
