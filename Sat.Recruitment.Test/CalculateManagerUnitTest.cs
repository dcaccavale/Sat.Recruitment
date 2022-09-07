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
        /// <summary>
        /// Instance Calculate amount
        /// </summary>
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

        /// <summary>
        /// Calculate amount for Normal user
        /// </summary>
        [Fact]
        public void CalculateAmount_Normal_Money_UP100()
        {
            decimal money = 200;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.Normal);
            var result = instance.Execute(money);
            decimal valueToComparate = (money + ( money * 0.12m));
            Assert.Equal(result, valueToComparate);

        }

        [Fact]
        public void CalculateAmount_Normal_Money_Between_10_100()
        {
            decimal money = 50;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.Normal);
            var result = instance.Execute(money);
            decimal valueToComparate = (money + (money * 0.8m));
            Assert.Equal(result, valueToComparate);

        }
        [Fact]
        public void CalculateAmount_Normal_Money_Down_10()
        {
            decimal money = 5;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.Normal);
            var result = instance.Execute(money);
            decimal valueToComparate = money;
            Assert.Equal(result, valueToComparate);

        }

        /// <summary>
        /// Calculate amount for super user
        /// </summary>
        [Fact]
        public void CalculateAmount_SuperUser_Money_UP100()
        {
            decimal money = 200;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.SuperUser);
            var result = instance.Execute(money);
            decimal valueToComparate = (money + (money * 0.2m));
            Assert.Equal(result, valueToComparate);

        }

        [Fact]
        public void CalculateAmount_SuperUser_Money_Between_10_100()
        {
            decimal money = 50;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.SuperUser);
            var result = instance.Execute(money);
            decimal valueToComparate = money ;
            Assert.Equal(result, valueToComparate);

        }
        [Fact]
        public void CalculateAmount_SuperUser_Money_Down_10()
        {
            decimal money = 5;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.SuperUser);
            var result = instance.Execute(money);
            decimal valueToComparate = money;
            Assert.Equal(result, valueToComparate);

        }
        /// <summary>
        /// Calculate amount for Premium user
        /// </summary>
        [Fact]
        public void CalculateAmount_Premium_Money_UP100()
        {
            decimal money = 200;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.Premium);
            var result = instance.Execute(money);
            decimal valueToComparate = (money + (money * 2m));
            Assert.Equal(result, valueToComparate);

        }

        [Fact]
        public void CalculateAmount_Premium_Money_Between_10_100()
        {
            decimal money = 50;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.Premium);
            var result = instance.Execute(money);
            decimal valueToComparate = money;
            Assert.Equal(result, valueToComparate);

        }
        [Fact]
        public void CalculateAmount_Premium_Money_Down_10()
        {
            decimal money = 5;
            var instance = CalculateUserAmountManager.GetCalculate(UserType.Premium);
            var result = instance.Execute(money);
            decimal valueToComparate = money;
            Assert.Equal(result, valueToComparate);

        }

    }
}
