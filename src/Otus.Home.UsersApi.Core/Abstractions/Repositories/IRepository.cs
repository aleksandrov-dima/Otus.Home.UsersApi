using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Otus.Home.UsersApi.Core.Domain;

namespace Otus.Home.UsersApi.Core.Abstractions.Repositories
{
    public interface IRepository<T>
        where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(Guid id);
        
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        
        Task DeleteRangeAsync(IEnumerable<T> entities);
        
        Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate);
        
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
    }
}