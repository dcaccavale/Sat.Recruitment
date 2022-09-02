using Sat.Recruitment.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Model
{
    public  class CalculatePercentaje
    {
        public static double Calculate(double value, double percentaje)
        {
           return value * percentaje;
        }
    }
    public class CalculateNormal: ICalculateAmount
    {
        public double Calculate(double money)
        {
            if (money > 100)
            {
                return money + CalculatePercentaje.Calculate(money, Convert.ToDouble(0.12));
            }
            else 
            {
               return money +  CalculatePercentaje.Calculate(money, Convert.ToDouble(0.8));
            }
        }
    }
    public class CalculateSuperUser: ICalculateAmount
    {
        public double Calculate(double money)
        {
            if (money > 100)
            {
                return money + CalculatePercentaje.Calculate(money, Convert.ToDouble(0.2));
            }
            return money;
        }
    }
    public class CalculatePremium : ICalculateAmount
    {
        public double Calculate(double money)
        {
            if (money > 100)
            {
                return money + (money * 2);
            }
            return money;
        }
    }
    

}
