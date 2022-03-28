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
    public class MovieRepository : CrudRepository<Movie>,IMovieRepository
    {
        public MovieRepository(MovieContext movieContext) : base(movieContext)
        {
        }

        


        

        private MovieContext MovieContext
        {
            get
            {
                return _movieContext as MovieContext;
            }
        }

    }
}
