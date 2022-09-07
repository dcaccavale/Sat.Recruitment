using Sat.Recruitment.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Model
{
    /// <summary>
    /// Auxiliary class to calculate percentaje
    /// </summary>
    internal class CalculateGif
    {
        internal static  decimal Calculate(decimal money, decimal percentage)
        {
            var gif = (money * percentage) + money;
            return gif;
        }
    }
    /// <summary>
    /// Class to calculate money to Normal User
    /// </summary>
    public class CalculateNormal : ICalculateAmount
    {
        public decimal Execute (decimal  money)
        {
            decimal multiplicator = 0;
            if (money > 100)
            {
                multiplicator = 0.12m;
            }
            else if(money < 100 && money > 10)
            {
                multiplicator =  0.8m;
            }
            return CalculateGif.Calculate(money, multiplicator);
        }
    }
    /// <summary>
    /// Class to calculate money to Super User
    /// </summary>
    public class CalculateSuperUser: ICalculateAmount
    {
        public decimal Execute (decimal  money)
        {
            decimal multiplicator = 0;
            if (money > 100)
            {
                multiplicator =  0.20m;
            }
            return CalculateGif.Calculate(money, multiplicator);
        }
    }
    /// <summary>
    /// Class to calculate money to Premium User
    /// </summary>
    public class CalculatePremium : ICalculateAmount
    {
        public decimal Execute (decimal  money)
        {
            decimal multiplicator = 0;
            if (money > 100)
            {
                multiplicator = 2m;
            }
            return CalculateGif.Calculate(money, multiplicator);
        }
    }
    

}
