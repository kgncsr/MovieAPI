using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.DataTier.Context;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;

namespace MovieAPI.DataTier.Concrete
{
    public class CategoryRepository :  CrudRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(MovieContext movieContext) : base(movieContext)
        {
        }
        private MovieContext movieContext { get { return _movieContext as MovieContext; } }

    }
}
