using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Model.Interfaces
{
    public  interface ICalculateAmount
    {
         decimal  Execute(decimal money);
    }
}
