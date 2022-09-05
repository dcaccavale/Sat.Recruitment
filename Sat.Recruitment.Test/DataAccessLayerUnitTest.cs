using System;
using System.Collections.Generic;

using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Moq;

using Sat.Recruitment.DataAccess;
using Sat.Recruitment.DataAccess.Repositories;
using Sat.Recruitment.Model;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("DataAccessLayerUnitTest", DisableParallelization = true)]
    public class DataAccessLayerUnitTest
    {
        private UserRepository _UserRepository;
        private Mock<SatRecruitmentContext> _mockSatContext;

        public DataAccessLayerUnitTest()
        {
            var data = new List<User>()
            {
                new User()
                {
                    IdGuid = Guid.NewGuid(),
                    Id = 1,
                    Email ="dos@doc.com",
                    Phone="22222222",
                    Name = "Name 1"
                },
                 new User()
                {
                    IdGuid = Guid.NewGuid(),
                    Id = 1,
                    Email ="dos@doc.com",
                    Phone="22222222",
                    Name = "Name 1"
                }

        }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptions<SatRecruitmentContext>();
            _mockSatContext = new Mock<SatRecruitmentContext>(optionsBuilder);
            Mock<DatabaseFacade> databaseFacade = new Mock<DatabaseFacade>(_mockSatContext.Object);
            databaseFacade.Setup(d => d.EnsureCreatedAsync(CancellationToken.None)).Returns(Task.FromResult(true));
            _mockSatContext.Setup(c => c.Database).Returns(databaseFacade.Object);
            _mockSatContext.Setup(c => c.Users).Returns(mockSet.Object);
           
            _UserRepository = new UserRepository(_mockSatContext.Object);
        }

        [Fact]
        public void TEstRepo()
        {

            var value = _UserRepository.GetAllAsync<User>().Result;
            Assert.Null(value);
        }

        [Fact]
        public void Test2()
        {

        }
    }
}
