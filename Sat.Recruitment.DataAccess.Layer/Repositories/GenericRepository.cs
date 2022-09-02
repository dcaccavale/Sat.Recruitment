using DataAccess;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess.Repositories
{
    public class GenericRepository<TData> : IGenericRepository<TData> where TData : Entity
    {
        protected readonly SetRecruitmentContext _dataContext;
        public GenericRepository(SetRecruitmentContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async  Task<TData> Add(TData data)
        {
            _dataContext.Set<TData>().Add(data);
            await _dataContext.SaveChangesAsync();
            return await GetById(data.IdGuid);
        }

        public async  Task<IEnumerable<TData>> GetAll()
        {
            var query = _dataContext.Set<TData>().AsQueryable();
            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<TData>> GetByCriteria(Expression<Func<TData, bool>> predicate = null)
        {
            var query = _dataContext.Set<TData>().AsQueryable();
            if (predicate != null)
                return await query.Where(predicate).ToArrayAsync();
            return  await query.ToArrayAsync(); 
        }

        public  async  Task<TData> GetById(Guid guid) 
        {
            var query = _dataContext.Set<TData>().AsQueryable();
            return await query.FirstOrDefaultAsync(data=> data.IdGuid == guid);
        }

        public async Task<TData> Update(TData data)
        {
            _dataContext.Set<TData>().Update(data);
            await _dataContext.SaveChangesAsync();
            return await GetById(data.IdGuid);
        }
    }
}
