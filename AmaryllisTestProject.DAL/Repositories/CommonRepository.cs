using AmaryllisTestProject.DAL.Entities;
using AmaryllisTestProject.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AmaryllisTestProject.DAL.Repositories
{
    public abstract class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {

        protected readonly IUnitOfWork _uow;

        public CommonRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public virtual async Task CreateAsync(T item)
        {
            if (item == null) throw new Exception("Значения модели не описаны");
            await _uow.Context.Set<T>().AddAsync(item);
            await _uow.CommitAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var dbEntry = await _uow.Context.Set<T>().FindAsync(id);
            if (dbEntry == null) throw new Exception("Значения модели не описаны");
            _uow.Context.Remove(dbEntry);
            await _uow.CommitAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await _uow.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _uow.Context.Set<T>()
                    .AsNoTracking()
                    .Where(predicate)
                    .ToListAsync();
            }
            return await _uow.Context.Set<T>()
                    .AsNoTracking()
                    .ToListAsync();
        }

        public virtual async Task UpdateAsync(T item)
        {
            var exist = await _uow.Context.Set<T>().FindAsync(item.Id);
            _uow.Context.Entry(exist).CurrentValues.SetValues(item);
            await _uow.CommitAsync();
        }

        public async Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _uow.Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

    }
}
