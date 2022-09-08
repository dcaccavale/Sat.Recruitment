using Microsoft.EntityFrameworkCore.Query;
using Sat.Recruitment.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataAccess.Repositories
{
    public interface IGenericRepositoryQueries
    {
        Task<IList<T>> GetAllAsync<T>(
         Expression<Func<T, bool>> predicate = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         int? take = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : Entity;
        Task<T> GetAsync<T>(Guid Id, Func<IQueryable<T>,
           IIncludableQueryable<T, object>> include = null) where T : Entity;
        Task<bool> Any<T>(Expression<Func<T, bool>> predicate) where T : Entity;
        Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : Entity;
     

    }

    public interface IGenericRepositoryOperations
    {
        Task<T> Add<T>(T entity) where T : Entity;
        Task<IList<T>> AddRange<T>(IList<T> entityList) where T : Entity;
        Task<T> Update<T>(T entity) where T : Entity;
        Task<T> Delete<T>(T entity) where T : Entity;
        Task<T> Remove<T>(T entity) where T : Entity;
    }
}
