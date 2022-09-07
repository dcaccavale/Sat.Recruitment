using Sat.Recruitment.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Service.Utils;
using Sat.Recruitment.Model.Entities;

namespace Sat.Recruitment.Model.Calculate
{
    /// <summary>
    /// Calculate amount Manager to create a claculator amount to especific user type 
    /// </summary>
    public class CalculateUserAmountManager
    {
        /// <summary>
        /// Return a Calculate amount to especific user type 
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public static  ICalculateAmount GetCalculate(UserType userType)
        {
            return ReflectionHelper.GetInstance<ICalculateAmount>(string.Format("Calculate{0}", userType.ToString()));
        }
    }
}
