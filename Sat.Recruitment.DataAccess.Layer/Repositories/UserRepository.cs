


using Microsoft.EntityFrameworkCore.Query;
using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess.Repositories
{
    /// <summary>
    /// Data access class for User business object
    /// </summary>
    public class UserRepository : GenericRepository, IUserRepository
    {

        public UserRepository(SatRecruitmentContext dataContext) : base(dataContext) { }


    }

}
