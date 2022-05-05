using Microsoft.EntityFrameworkCore;
using MovieAPI.Entities.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataTier.Interfaces
{
    public interface ICrudRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get;}    
        Task<IQueryable<T>> GetAllAsync(bool track=true);

        Task<long> GetCountAsync();
        Task<IQueryable<T>> GetFilterAsync(Expression<Func<T,bool>>predicate, bool track = true);
        Task<T> GetSingleFilterAsync(Expression<Func<T, bool>> predicate, bool track = true);
        Task<T> GetByIdAsync(int id, bool track = true);
         
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(IEnumerable<T> adds);
        bool Delete(T model);
        bool DeleteByIdAsync(int id);
        bool DeleteRange(IEnumerable<T> deletes);
        bool Update(T model);
    }
}
