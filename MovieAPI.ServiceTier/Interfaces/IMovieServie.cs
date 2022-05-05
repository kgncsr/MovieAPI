
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface IMovieService
    {
        Task<bool> AddAsync(MovieDto model);
        Task<IQueryable<MovieDto>> GetAllAsync(bool track=true);
        Task<IEnumerable<MovieDto>> FindMoviesYearMonth(int year, int month, bool track = true);
        Task<decimal> FindSumYearAsync(int year);

        Task<List<MovieDto>> MoviesByImdbGreaterOrderBy(long imdb, bool track=true);

        Task<List<MovieDto>> FindByYearAsync(int year, bool track = true);
        Task<IEnumerable<MovieManagerDto>> FindMoviesByManagerId(int managerId, bool track = true);

        Task<long> GetCountAsync();

        Task<MovieDto> GetByIdAsync(int id, bool track = true);
        Task<bool> AddRangeAsync(IEnumerable<Movie> adds);
        bool Delete(Movie model);
        bool DeleteById(int id);
        bool DeleteRange(IEnumerable<Movie> deletes);
        public bool Update(MovieUpdateDto movieUpdateDto);
    }
}
