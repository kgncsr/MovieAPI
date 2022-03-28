using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataTier.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MovieContext>
    {
        public MovieContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MovieContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConfigurationPath);
            return new MovieContext(dbContextOptionsBuilder.Options);
        }
    }
}
