
using Microsoft.EntityFrameworkCore;
using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataTier.Context
{
    public class MovieContext : DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
