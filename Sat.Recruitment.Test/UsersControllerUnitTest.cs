
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Service;
using Sat.Recruitment.Test.Helpers;
using System;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("UsersControllerUnitTest", DisableParallelization = true)]
    public class UsersControllerUnitTest
    {
      
        private readonly UsersController _usersController;

        public UsersControllerUnitTest()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                     .UseStartup<Startup>()
                     .Build();
            var serviceProvider = new DependencyResolverHelper(webHost).GetService<IUserServiceModel>();
            var logger = new DependencyResolverHelper(webHost).GetService<ILogger<UsersController>>();
            _usersController = new UsersController(serviceProvider, logger);

        }

        [Fact]
        public async void UsersController_CreateUser_Status200OK()
        {
            Random random = new Random();
            var userRequest = new UserRequest
            {
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                UserType = UserType.Normal,
                Money = random.Next(random.Next(0, 200)),
            };
            var response = await _usersController.CreateUser(userRequest);
            var okResult = response as ObjectResult;
            Assert.NotNull(response);
             Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async void UsersController_CreateUser_DuplicateError_Status500InternalServerError()
        {
            Random random = new Random();
            var userRequest = new UserRequest
            {
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                UserType = UserType.Normal,
                Money = random.Next(random.Next(0, 200)),
            };
            var response = await _usersController.CreateUser(userRequest);
            var response2 = await _usersController.CreateUser(userRequest);
            var okResult = response2 as ObjectResult;
            Assert.NotNull(response);
            Assert.Equal(StatusCodes.Status500InternalServerError, okResult.StatusCode);
        }

    }
}
