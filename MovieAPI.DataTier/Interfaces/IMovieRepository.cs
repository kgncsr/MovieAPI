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

    }
}
