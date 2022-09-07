using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Model.Interfaces
{
    /// <summary>
    /// Use to extend other type of calculate amunt for a user type 
    /// </summary>
    public  interface ICalculateAmount
    {
         decimal  Execute(decimal money);
    }
}
