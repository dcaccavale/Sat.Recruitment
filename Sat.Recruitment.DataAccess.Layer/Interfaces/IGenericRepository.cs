using Sat.Recruitment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess.Repositories
{
    public  interface IGenericRepository<TData>
    {
        Task<TData> Add(TData data);
        Task<TData> Update(TData data);
        Task<IEnumerable<TData>> GetAll();
        Task<TData> GetById(Guid guid);
        Task<IEnumerable<TData>> GetByCriteria(Expression<Func<TData, bool>> predicate = null);
        Task<bool> Any<T>(Expression<Func<T, bool>> predicate);

    }
}
