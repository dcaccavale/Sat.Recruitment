using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Sat.Recruitment.Api;
using Sat.Recruitment.DataAccess.Repositories;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Test.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("DataAccessLayerUnitTest", DisableParallelization = true)]
    public class DataAccessLayerUnitTest
    {

        private readonly IUserRepository _UserRepository;
        public DataAccessLayerUnitTest()
        {
            var webHost = WebHost.CreateDefaultBuilder()
              .UseStartup<Startup>()
              .Build();
            _UserRepository = new DependencyResolverHelper(webHost).GetService<IUserRepository>();

        }

        /// <summary>
        /// Test Get All Async
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task FirstOrDefaultAsync()
        {
            var guid = Guid.NewGuid(); 
            User user = new User
            {
                IdGuid = guid,
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                Type = UserType.Normal,
                Money = 125
            };
            await _UserRepository.Add<User>(user);
            var result = await _UserRepository.FirstOrDefaultAsync<User>(u=> u.IdGuid == guid);
           // var okResult = result as ObjectResult;
            Assert.NotNull(result);
            Assert.True(result.IdGuid == guid);
        }

        /// <summary>
        /// Test Get All Async
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllAsync()
        {
            var guid = Guid.NewGuid();
            User user = new User
            {
                IdGuid = guid,
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                Type = UserType.Normal,
                Money = 125
            };
            await _UserRepository.Add<User>(user);

            var result = await _UserRepository.GetAllAsync<User>();
            Assert.NotNull(result);
            Assert.True( result.Count() > 0);
        }

        /// <summary>
        /// Test Get All Async
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllAsyncByCriteria()
        {
            var guid = Guid.NewGuid();
            User user = new User
            {
                IdGuid = guid,
                Name = "prueba",
                Email =  "prueba@gmail.com",
                Address = "calle charles 855",
                Phone = "5255555555",
                Type = UserType.Normal,
                Money = 125
            };
            await _UserRepository.Add<User>(user);

            var result = await _UserRepository.GetAllAsync<User>(u=> u.Id == 1);
            Assert.NotNull(result);
            Assert.True(result.Count() == 1 && result[0].Id == 1);
        }

        /// <summary>
        /// Test GetAsync
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAsync()
        {
            var guid = Guid.NewGuid();
            User user = new User
            {
                IdGuid = guid,
                Name = "prueba",
                Email = "prueba@gmail.com",
                Address = "calle charles 855",
                Phone = "5255555555",
                Type = UserType.Normal,
                Money = 125
            };
            await _UserRepository.Add<User>(user);
            var result = await _UserRepository.GetAsync<User>(guid);
            Assert.NotNull(result);
            Assert.True(guid == result.IdGuid);
        }


        [Fact]
        public async Task Any()
        {
            var guid = Guid.NewGuid();
            User user = new User
            {
                IdGuid = guid,
                Name = "prueba",
                Email = "prueba@gmail.com",
                Address = "calle charles 855",
                Phone = "5255555555",
                Type = UserType.Normal,
                Money = 125
            };
            await _UserRepository.Add<User>(user);
            Assert.True(await _UserRepository.Any<User>(u => u.IdGuid == guid));
        }


        [Fact]
        public async Task Add()
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
            var result = await _UserRepository.Add<User>(user);
            var userAdd = await _UserRepository.FirstOrDefaultAsync<User>(u=> u.Id == user.Id);
            Assert.NotNull(userAdd);
            Assert.True(userAdd.IdGuid == user.IdGuid && userAdd.Id == user.Id && userAdd.Address == user.Address &&
                userAdd.Email == user.Email && userAdd.Name == user.Name && userAdd.Phone == user.Phone && userAdd.Type == user.Type);
            Assert.True(user.State == StateEntity.Created);
        }

        [Fact]
        public async Task Update()
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
            var result = await _UserRepository.Add<User>(user);
            var userAdd = await _UserRepository.FirstOrDefaultAsync<User>(u => u.Id == user.Id);
            userAdd.Name = userAdd.Name + "Modificate";
            var userUpdate = await _UserRepository.Update<User>(userAdd);

            Assert.NotNull(userUpdate);
            Assert.True(userUpdate.State == StateEntity.Updated);

        }


        [Fact]
        public async Task Delete()
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
            var result = await _UserRepository.Add<User>(user);
            var userAdd = await _UserRepository.FirstOrDefaultAsync<User>(u => u.Id == user.Id);
           
            var userDelete = await _UserRepository.Delete<User>(userAdd);

            Assert.NotNull(userDelete);
            Assert.True(userDelete.State == StateEntity.Deleted);

        }


        [Fact]
        public async Task Remove()
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
            var result = await _UserRepository.Add<User>(user);
            var userAdd = await _UserRepository.FirstOrDefaultAsync<User>(u => u.Id == user.Id);
            await _UserRepository.Remove<User>(userAdd);
            var userRemove = await _UserRepository.FirstOrDefaultAsync<User>(u => u.Id == user.Id);
            Assert.Null(userRemove);
        
        }
  

    }
}
