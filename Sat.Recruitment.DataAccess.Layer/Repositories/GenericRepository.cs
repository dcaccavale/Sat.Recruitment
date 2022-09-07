using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess.Repositories
{
    /// <summary>
    /// base class to inherit repositories of bussiness entities objects that you want to persist through EF ORM
    /// </summary>
    public class GenericRepository : IGenericRepositoryQueries , IGenericRepositoryOperations
    {
        protected readonly SatRecruitmentContext _dataContext;
        public GenericRepository(SatRecruitmentContext dataContext)
        {
            _dataContext = dataContext;
        }
        /// <summary>
        /// Generic get all entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="take"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async  Task<IList<T>> GetAllAsync<T>(
          Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          int? take = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : Entity
        {
            var query = _dataContext.Set<T>().AsQueryable();
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (take.HasValue)
                query = query.Take(Convert.ToInt32(take));


            return  query.ToListAsync<T>().Result;
        }

        /// <summary>
        /// Generic Get by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(Guid Id, Func<IQueryable<T>,
            IIncludableQueryable<T, object>> include = null) where T : Entity
        {
            var query = _dataContext.Set<T>().AsQueryable();
            if (include != null)
                query = include(query);
            return await query.SingleOrDefaultAsync(s => s.IdGuid == Id);
        }

        /// <summary>
        /// Return true if exist any object 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> Any<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            var query = _dataContext.Set<T>().AsQueryable();
            return await query.AnyAsync(predicate);
        }

        /// <summary>
        /// Generic First Or Default Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : Entity
        {
            var query = _dataContext.Set<T>().AsQueryable();
            if (include != null)
                query = include(query);
            if (predicate != null)
                return await query.FirstOrDefaultAsync(predicate);
            return await query.FirstOrDefaultAsync();

        }
        /// <summary>
        /// Generic Add Entity to Set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Add<T>(T entity) where T : Entity
        {
            entity.State = StateEntity.Created;
            entity.CreateDateTime = DateTime.Now;
            _dataContext.Set<T>().Add(entity);
            await _dataContext.SaveChangesAsync();
            return await GetAsync<T>(entity.IdGuid);
        }

        /// <summary>
        /// Generic update entity 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Update<T>(T entity) where T : Entity
        {
            entity.State = StateEntity.Updated;
            entity.UpdatedDateTime = DateTime.Now;
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync();
            return await GetAsync<T>(entity.IdGuid);
        }
        /// <summary>
        /// Generic fisical Delete 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Remove<T>(T entity) where T : Entity
        {
            _dataContext.Set<T>().Remove(entity);
            _dataContext.SaveChanges();
            return await GetAsync<T>(entity.IdGuid);
        }

        /// <summary>
        /// Generic fisical Delete 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Delete<T>(T entity) where T : Entity
        {
            entity.State = StateEntity.Deleted;
            entity.DeleteDateTime = DateTime.Now;
            _dataContext.Set<T>().Update(entity);
            _dataContext.SaveChanges();
            return await GetAsync<T>(entity.IdGuid);
        }


    }
}
