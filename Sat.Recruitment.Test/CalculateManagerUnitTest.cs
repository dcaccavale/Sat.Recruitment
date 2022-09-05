using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Model;
using Sat.Recruitment.Model.Calculate;
using Sat.Recruitment.Model.Entities;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("CalculateManagerUnitTest", DisableParallelization = true)]
    public class CalculateManagerUnitTest
    {
        public CalculateUserAmountManager calculateManager { get; set; }
        [Fact]
        public void CreateValidInstance_CalculateNormal()
        {
            var instance = CalculateUserAmountManager.GetCalculate(UserType.Normal);
            Assert.NotNull(instance);
            Assert.IsType<CalculateNormal>(instance);
            
        }

        [Fact]
        public void CreateValidInstance_CalculateSuperUSer()
        {
            var instance = CalculateUserAmountManager.GetCalculate(UserType.SuperUser);
            Assert.NotNull(instance);
            Assert.IsType<CalculateSuperUser>(instance);

        }

        [Fact]
        public void CreateValidInstance_CalculatePremium()
        {
           var instance = CalculateUserAmountManager.GetCalculate(UserType.Premium);
            Assert.NotNull(instance);
            Assert.IsType<CalculatePremium>(instance);

        }

        [Fact]
        public void CreateInValidInstance()
        {
            var instance = CalculateUserAmountManager.GetCalculate(UserType.Normal);
            Assert.NotNull(instance);
            Assert.IsNotType<CalculatePremium>(instance);

        }

    }
}
