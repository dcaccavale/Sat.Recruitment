
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Sat.Recruitment.Api;
using Sat.Recruitment.DataAccess;
using Sat.Recruitment.DataAccess.Repositories;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("DataAccessLayerUnitTest", DisableParallelization = true)]
    public class DataAccessLayerUnitTest
    {
        private int countList = 25;
        private readonly IUserRepository _UserRepository;
        public DataAccessLayerUnitTest()
        {
            var webHost = WebHost.CreateDefaultBuilder()
              .UseStartup<Startup>()
              .Build();
            _UserRepository = new DependencyResolverHelper(webHost).GetService<IUserRepository>();
         
       }

        private List<User> CreateManyUsersTest(int length)
        {
            Random random = new Random();
            List<User> listUSer = new List<User>();
            for (int i = 0; i < length; i++)
            {
                var guid = Guid.NewGuid();

                listUSer.Add(new User
                {
                    IdGuid = guid,
                    Name = "prueba" + guid.ToString(),
                    Email = guid + "prueba@gmail.com",
                    Address = guid + "calle charles 855",
                    Phone = guid + "5255555555",
                    Type = UserType.Normal,
                    Money = random.Next(random.Next(0, 200)),
                });
            }
            return listUSer;

        }

        private User CreateUserTest()
        {
            var guid = Guid.NewGuid();
            Random random = new Random();
            return new User
            {
                IdGuid = guid,
                Name = "prueba" + Guid.NewGuid().ToString(),
                Email = Guid.NewGuid() + "prueba@gmail.com",
                Address = Guid.NewGuid() + "calle charles 855",
                Phone = Guid.NewGuid() + "5255555555",
                Type = UserType.Normal,
                Money = random.Next(random.Next(0, 200)),
            };
        }

        /// <summary>
        /// Test Get All Async
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task FirstOrDefaultAsync()
        {
            User user = CreateUserTest();
            await _UserRepository.Add<User>(user);
            var result = await _UserRepository.FirstOrDefaultAsync<User>(u => u.IdGuid == user.IdGuid);
            Assert.NotNull(result);
            Assert.True(result.IdGuid == user.IdGuid);
        }

        /// <summary>
        /// Test Get All Async
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllAsync()
        {
            _UserRepository.initModel(countList);
            var result = await _UserRepository.GetAllAsync<User>();
            Assert.NotNull(result);
            Assert.True(result.Count() == countList);
        }

        /// <summary>
        /// Test Get All Async
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllAsyncByCriteria()
        {
            User user = CreateUserTest();
            await _UserRepository.Add<User>(user);

            var result = await _UserRepository.GetAllAsync<User>(u => u.IdGuid == user.IdGuid);
            Assert.NotNull(result);
            Assert.True(result.Count() == 1 && result[0].IdGuid == user.IdGuid);
        }

        /// <summary>
        /// Test GetAsync
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAsync()
        {
            User user = CreateUserTest();
            await _UserRepository.Add<User>(user);
            var result = await _UserRepository.GetAsync<User>(user.IdGuid);
            Assert.NotNull(result);
            Assert.True(user.IdGuid == result.IdGuid);
        }


        [Fact]
        public async Task Any()
        {
            User user = CreateUserTest();
            await _UserRepository.Add<User>(user);
            Assert.True(await _UserRepository.Any<User>(u => u.IdGuid == user.IdGuid));
        }


        [Fact]
        public async Task Add()
        {
            User user = CreateUserTest();
            var result = await _UserRepository.Add<User>(user);
            var userAdd = await _UserRepository.FirstOrDefaultAsync<User>(u => u.IdGuid == user.IdGuid);
            Assert.NotNull(userAdd);
            Assert.True(userAdd.IdGuid == user.IdGuid && userAdd.Id == user.Id && userAdd.Address == user.Address &&
                userAdd.Email == user.Email && userAdd.Name == user.Name && userAdd.Phone == user.Phone && userAdd.Type == user.Type);
            Assert.True(user.State == StateEntity.Created);
        }


        [Fact]
        public async Task AddRange()
        {
            _UserRepository.initModel(0);
            Random ran = new Random();
            int count = ran.Next(0, 250);
            List<User> userList =  CreateManyUsersTest(count);
            await _UserRepository.AddRange<User>(userList);
            var result = await _UserRepository.GetAllAsync<User>();
            Assert.NotNull(result);
            Assert.True(result.Count() == count );
        }

        [Fact]
        public async Task Update()
        {
            User user = CreateUserTest();
            var result = await _UserRepository.Add<User>(user);
            var userAdd = await _UserRepository.FirstOrDefaultAsync<User>(u => u.IdGuid == user.IdGuid);
            userAdd.Name = userAdd.Name + "Modificate";
            var userUpdateResult = await _UserRepository.Update<User>(userAdd);
            var userUpdate = await _UserRepository.FirstOrDefaultAsync<User>(u => u.IdGuid == user.IdGuid);

            Assert.NotNull(userUpdate);
            Assert.True(userUpdate.State == StateEntity.Updated);
            Assert.Contains("Modificate", userUpdate.Name);

        }


        [Fact]
        public async Task Delete()
        {
            User user = CreateUserTest();
            var result = await _UserRepository.Add<User>(user);
            var userAdd = await _UserRepository.FirstOrDefaultAsync<User>(u => u.IdGuid == user.IdGuid);

            var userDelete = await _UserRepository.Delete<User>(userAdd);

            Assert.NotNull(userDelete);
            Assert.True(userDelete.State == StateEntity.Deleted);

        }


        [Fact]
        public async Task Remove()
        {
            User user = CreateUserTest();
            var result = await _UserRepository.Add<User>(user);
            var userAdd = await _UserRepository.FirstOrDefaultAsync<User>(u => u.IdGuid == user.IdGuid);
            await _UserRepository.Remove<User>(userAdd);
            var userRemove = await _UserRepository.FirstOrDefaultAsync<User>(u => u.IdGuid == user.IdGuid);
            Assert.Null(userRemove);

        }


    }
}

