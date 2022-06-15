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

            var result = entityEntry.State == EntityState.Added;
            await _movieContext.SaveChangesAsync();
            return result;



        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> adds)
        {
            await Table.AddRangeAsync(adds);
            await _movieContext.SaveChangesAsync();
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            var result =  entityEntry.State == EntityState.Deleted;
            _movieContext.SaveChanges();
            return result;


        }

        public bool DeleteByIdAsync(int id)
        {
            var result = Table.FirstOrDefault(a => a.Id==id);

            return Delete(result);
        }

        public bool DeleteRange(IEnumerable<T> deletes)
        {
            Table.RemoveRange(deletes);
            return true;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            var result =  entityEntry.State == EntityState.Modified;
            _movieContext.SaveChanges();
            return result;

        }

        public Task<IQueryable<T>> GetAllAsync(bool track)
        {
            var result = Table.AsQueryable();
            if (!track)
            {
                result.AsNoTracking();
            }
            var task = new Task<IQueryable<T>>(() => result);
            task.Start();
            return task;
        }

        public Task<T> GetByIdAsync(int id, bool track = true)
        {
            var query = Table.AsQueryable();
            if (!track)
            {
                query.AsNoTracking();
            }
            return query.FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public async Task<long> GetCountAsync()
        {
            return await Table.LongCountAsync();
        }

        public Task<IQueryable<T>> GetFilterAsync(Expression<Func<T, bool>> predicate, bool track = true)
        {
            var query = Table.Where(predicate);
            if (!track)
            {
                query.AsNoTracking();
            }
            var task = new Task<IQueryable<T>>(() => Table.Where(predicate));
            task.Start();
            return task;
        }

        public async Task<T> GetSingleFilterAsync(Expression<Func<T, bool>> predicate, bool track = true)
        {
            var query = Table.AsQueryable(); 
            if (!track)
            {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

    }
}
