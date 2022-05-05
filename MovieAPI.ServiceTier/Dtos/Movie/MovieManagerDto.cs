using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Dtos.Movie
{
    public class MovieManagerDto : MovieDto
    {
        public MovieManagerDto()
        {
            Manager = new SaveManagerDto();
        }
        public SaveManagerDto Manager { get; set; }
    }
}
