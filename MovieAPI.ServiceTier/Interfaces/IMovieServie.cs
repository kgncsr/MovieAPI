
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.ServiceTier.Responses;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface IMovieService
    {
        #region  ended
        Task<DataResponse<IEnumerable<MovieDto>>> GetAllAsync(bool track = true);
        Task<DataResponse<List<MovieDto>>> FindByYearAsync(int year, bool track = true);
        Task<DataResponse<IEnumerable<MovieDto>>> FindMoviesYearMonth(int year, int month, bool track = true);
        Task<DataResponse<List<MovieDto>>> MoviesByImdbGreaterOrderBy(long imdb, bool track = true);
        Task<DataResponse<IEnumerable<MovieManagerDto>>> FindMoviesByManagerId(int managerId, bool track = true);
        Task<DataResponse<long>> GetCountAsync();

        Task<decimal> FindSumYearAsync(int year);


        #endregion



        Task<bool> AddAsync(MovieCreateDto model);
       
        Task<MovieDto> GetByIdAsync(int id, bool track = true);
        Task<bool> AddRangeAsync(IEnumerable<Movie> adds);
        bool Delete(Movie model);
        bool DeleteById(int id);
        bool DeleteRange(IEnumerable<Movie> deletes);
        public bool Update(MovieUpdateDto movieUpdateDto);
    }
}
