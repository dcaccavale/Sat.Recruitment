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
    public class CalculateUserAmountManager
    {

        public static  ICalculateAmount GetCalculate(UserType userType)
        {
            return ReflectionHelper.GetInstance<ICalculateAmount>(string.Format("Calculate{0}", userType.ToString()));
        }
    }
}
