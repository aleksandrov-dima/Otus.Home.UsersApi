using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Otus.Home.UsersApi.Core.Abstractions.Repositories;
using Otus.Home.UsersApi.Core.Domain;

namespace Otus.Home.UsersApi.DataAccess.Repositories
{
    public class EfRepository<T> 
        : IRepository<T> 
        where T: BaseEntity
    {
        private readonly DataContext _dataContext;

        public EfRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var entities = await _dataContext.Set<T>().ToListAsync();

                return entities;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                
                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _dataContext.AddAsync(entity);
                await _dataContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _dataContext.Update(entity);
                await _dataContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }
            
            try
            {
                _dataContext.Remove(entity);
                await _dataContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be removed");
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteRangeAsync)} entity must not be null");
            }
            
            try
            {
                _dataContext.RemoveRange(entities);
                await _dataContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entities)} could not be removed");
            }
        }

        public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dataContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dataContext.Set<T>().Where(predicate).ToListAsync();
        }
    }
}