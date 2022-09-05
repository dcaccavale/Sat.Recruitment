using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Model;
using Sat.Recruitment.Model.Calculate;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("CalculateManagerUnitTest", DisableParallelization = true)]
    public class CalculateManagerUnitTest
    {
        public CalculateManager calculateManager { get; set; }
        [Fact]
        public void CreateValidInstance_CalculateNormal()
        {
            CalculateManager manager = new CalculateManager();
            var instance = manager.GetCalculate(Model.UserType.Normal);
            Assert.NotNull(instance);
            Assert.IsType<CalculateNormal>(instance);
            
        }

        [Fact]
        public void CreateValidInstance_CalculateSuperUSer()
        {
            CalculateManager manager = new CalculateManager();
            var instance = manager.GetCalculate(Model.UserType.SuperUser);
            Assert.NotNull(instance);
            Assert.IsType<CalculateSuperUser>(instance);

        }

        [Fact]
        public void CreateValidInstance_CalculatePremium()
        {
            CalculateManager manager = new CalculateManager();
            var instance = manager.GetCalculate(Model.UserType.Premium);
            Assert.NotNull(instance);
            Assert.IsType<CalculatePremium>(instance);

        }

        [Fact]
        public void CreateInValidInstance()
        {
            CalculateManager manager = new CalculateManager();
            var instance = manager.GetCalculate(Model.UserType.Normal);
            Assert.NotNull(instance);
            Assert.IsNotType<CalculatePremium>(instance);

        }

    }
}
