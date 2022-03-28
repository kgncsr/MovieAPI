using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface ICrudService<T>
    {
        Task<IQueryable<T>> GetAllAsync();

        Task<long> GetCountAsync();
        Task<IQueryable<T>> GetFilterAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleFilterAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);

        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(IEnumerable<T> adds);

        bool Delete(T model);
        Task<bool> DeleteByIdAsync(int id);
        bool DeleteRange(IEnumerable<T> deletes);
    }
}
