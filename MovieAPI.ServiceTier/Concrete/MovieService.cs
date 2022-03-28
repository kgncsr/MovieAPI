using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Concrete
{
    public class MovieService : ICrudService<Movie>, IMovieService
    {
        private readonly IMovieRepository m_movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            m_movieRepository = movieRepository;
        }

        #region Generic
        public Task<bool> AddAsync(Movie model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(IEnumerable<Movie> adds)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Movie model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRange(IEnumerable<Movie> deletes)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Movie>> GetAllAsync()
        {
           return await  m_movieRepository.GetAllAsync();
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Movie>> GetFilterAsync(Expression<Func<Movie, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetSingleFilterAsync(Expression<Func<Movie, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
