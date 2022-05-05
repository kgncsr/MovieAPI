using Microsoft.EntityFrameworkCore;
using MovieAPI.DataTier.Context;

using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataTier.Concrete
{
    public class MovieRepository : CrudRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieContext movieContext) : base(movieContext)
        {
        }
        private MovieContext movieContext
        {
            get
            {
                return _movieContext as MovieContext;
            }
        }

        #region callback
        public List<Movie> findMoviesYearMonthCallBack(int year, int month, bool track = true)
        {
            //var movies = movieContext.Movies.Where(a => a.SceneDate.Year == year && a.SceneDate.Month == month).ToList();
            //return movies;
            var query = movieContext.Movies.Where(a => a.SceneDate.Year == year && a.SceneDate.Month == month);
            if (!track)
            {
                query.AsNoTracking();
            }
            return query.ToList();

        }
        public List<Movie> findByYearCallBack(int year, bool track)
        {
      
            var query = movieContext.Movies.Where(a => a.SceneDate.Year == year);
            if (!track)
            {
                query.AsNoTracking();
            }
            return query.ToList();

        }
        public IEnumerable<Movie> findByManagerCallBack(int managerId, bool track)
        {
            var query = movieContext.Movies.Include(a=>a.Manager).Where(a => a.ManagerId == managerId);
            if (!track)
            {
                query.AsNoTracking();
            }
            return query.ToList();
        }
        public decimal findSumYearCallback(int year)
        {
            var sum = movieContext.Movies
                .Where(a => a.SceneDate.Year == year)
                .Sum(b => b.Cost);

            return sum;
        }
        public List<Movie> moviesByImdbGreaterOrderByCallBack(long imdb,bool track)
        {
            var query = movieContext.Movies.Where(a => a.Imdb > imdb).OrderBy(a => a.Imdb);
            if (!track)
            {
                query.AsNoTracking();
            }
            return query.ToList();
        }
        #endregion

        public Task<IEnumerable<Movie>> FindMoviesYearMonth(int year, int month,bool track=true)
        {
            var task = new Task<IEnumerable<Movie>>(()=>findMoviesYearMonthCallBack(year,month,track));
            task.Start();
          
            return task;
        }
        public Task<List<Movie>> FindByYear(int year, bool track = true)
        {
            var task = new Task<List<Movie>>(() => findByYearCallBack(year,track));
            task.Start();
            return task;
        }
        public Task<IEnumerable<Movie>> FindMoviesByManagerId(int managerId, bool track = true)
        {
            var task = new Task<IEnumerable<Movie>>(() => findByManagerCallBack(managerId,track));
            task.Start();
            return task;
        }
        public Task<decimal> FindSumYearAsync(int year)
        {
            var task = new Task<decimal>(() => findSumYearCallback(year));
            task.Start();
            return task;
        }
        public Task<List<Movie>> MoviesByImdbGreaterOrderBy(long imdb,bool track=true)
        {
            var task = new Task<List<Movie>>(()=>moviesByImdbGreaterOrderByCallBack(imdb,track));
            task.Start();
            return task;
        }
    }
}
