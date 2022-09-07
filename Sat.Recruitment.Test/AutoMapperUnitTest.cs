
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Sat.Recruitment.Api;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Model.Request;
using Sat.Recruitment.Model.Response;
using Sat.Recruitment.Test.Helpers;
using System;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("AutoMapperUnitTest", DisableParallelization = true)]
    public class AutoMapperUnitTest
    {
        private readonly IMapper _mapper;

        public AutoMapperUnitTest()
        {
            var webHost = WebHost.CreateDefaultBuilder()
              .UseStartup<Startup>()
              .Build();
            _mapper = new DependencyResolverHelper(webHost).GetService<IMapper>();

        }
       
        [Fact]
        public void Map_User_To_UserResponse()
        {
            User user = new User
            {
                IdGuid = Guid.NewGuid(),
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                Type = UserType.Normal,
                Money = 125
            };
            var result = _mapper.Map<UserResponse>(user);
            Assert.NotNull(result);
            Assert.True(result.IdGuid == user.IdGuid  && result.Address == user.Address &&
                result.Email == user.Email && result.Name == user.Name && result.Phone == user.Phone && result.UserType == user.Type);
            Assert.IsType<UserResponse>(result);
        }

  
        [Fact]
        public void Map_UserRequest_To_User()
        {
            UserRequest user = new UserRequest
            {
                IdGuid = Guid.NewGuid(),
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                UserType = UserType.Normal,
                Money = 125
            };
            var result = _mapper.Map<User>(user);
            Assert.NotNull(result);
            Assert.True(result.IdGuid == user.IdGuid && result.Address == user.Address &&
                result.Email == user.Email && result.Name == user.Name && result.Phone == user.Phone && result.Type == user.UserType);
            Assert.IsType<User>(result);
        }

    }
}
