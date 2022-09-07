using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Utils.Extensions;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Service;
using Sat.Recruitment.Test.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("ServiceModelUnitTest", DisableParallelization = true)]
    public class ServiceModelUnitTest
    {
        private readonly IUserServiceModel _serviceProvider; 

        public ServiceModelUnitTest()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                     .UseStartup<Startup>()
                     .Build();
            _serviceProvider = new DependencyResolverHelper(webHost).GetService<IUserServiceModel>();
           
        }
    

        [Fact]
        public async Task CreateUserOk()
        {
            Random random = new Random();
         
            var userRequest = new UserRequest
            {
                IdGuid = Guid.NewGuid(),
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() +"calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                UserType = UserType.Normal,
                Money = random.Next(random.Next(0, 200)),
            };
            var response = await _serviceProvider.Create(userRequest);
            Assert.True(userRequest.IdGuid == response.IdGuid);
        }


        [Fact]
        public async Task CreateUser_Fail_Duplicate()
        {
            Random random = new Random();
            var userRequest = new UserRequest
            {
                IdGuid = Guid.NewGuid(),
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                UserType = UserType.Normal,
                Money = random.Next(random.Next(0, 200)),
            };
            var response = await _serviceProvider.Create(userRequest);

            await Assert.ThrowsAsync<ValidationException>(() => _serviceProvider.Create(userRequest));
        }

        [Fact]
        public async Task CreateUser_Fail_RequiredField()
        {
            Random random = new Random();

            var userRequest = new UserRequest
            {
                IdGuid = Guid.NewGuid(),
                Name = String.Empty,
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                UserType = UserType.Normal,
                Money = random.Next(random.Next(0, 200)),
            };
            await Assert.ThrowsAsync<ValidationException>(() => _serviceProvider.Create(userRequest));
        }

        [Fact]
        public async Task CreateUser_Fail_BadFormatEmail()
        {
            Random random = new Random();
            var userRequest = new UserRequest
            {
                IdGuid = Guid.NewGuid(),
                Name = String.Empty,
                Email = "123456",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                UserType = UserType.Normal,
                Money = random.Next(random.Next(0, 200)),
            };
            await Assert.ThrowsAsync<ValidationException>(() => _serviceProvider.Create(userRequest));
        }
    }
}
