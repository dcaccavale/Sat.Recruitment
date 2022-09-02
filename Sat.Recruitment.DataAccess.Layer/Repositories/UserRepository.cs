
using Sat.Recruitment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sat.Recruitment.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User> :IUserRepository 
    {

        public UserRepository(SatRecruitmentContext dataContext) : base(dataContext) { }
    }
}
