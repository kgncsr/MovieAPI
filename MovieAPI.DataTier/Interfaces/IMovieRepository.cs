using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataTier.Interfaces
{
    public interface IMovieRepository : ICrudRepository<Movie>
    {
        Task<IEnumerable<Movie>> FindMoviesYearMonth(int year, int month,bool track=true);
        Task<List<Movie>> FindByYear(int year, bool track=true);
        Task<IEnumerable<Movie>> FindMoviesByManagerId(int managerId, bool track=true);
        Task<decimal> FindSumYearAsync(int year);
        Task<List<Movie>> MoviesByImdbGreaterOrderBy(long imdb, bool track=true);
    } 
}
