using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieAPI.DataTier.Context;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataTier.Concrete
{
    public class CrudRepository<T> : ICrudRepository<T> where T : BaseEntity
    {
        protected readonly MovieContext _movieContext;

        public CrudRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public DbSet<T> Table { get => _movieContext.Set<T>(); }
        
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> adds)
        {
            await Table.AddRangeAsync(adds);
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
           var result =await Table.FirstOrDefaultAsync(a => a.Id.Equals(id));
            return Delete(result);
        }

        public bool DeleteRange(IEnumerable<T> deletes)
        {
            Table.RemoveRange(deletes);
            return true;
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            var task = new Task<IQueryable<T>>(() => Table.AsQueryable());
            task.Start();
            return task;
        }

        public Task<T> GetByIdAsync(int id)
        {
            return Table.FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public async Task<long> GetCountAsync()
        {
            return await Table.LongCountAsync();
        }

        public Task<IQueryable<T>> GetFilterAsync(Expression<Func<T, bool>> predicate)
        {
            var task = new Task<IQueryable<T>>(() => Table.Where(predicate));
            task.Start();
            return task;
        }

        public  Task<T> GetSingleFilterAsync(Expression<Func<T, bool>> predicate)
        {
            var task = new Task<T>(() => Table.Where(predicate).FirstOrDefault());
            task.Start();
            return  task;
        }


    }
}
