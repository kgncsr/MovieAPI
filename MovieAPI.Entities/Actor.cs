using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.Entities;
using MovieAPI.Entities.Cammon;

namespace MovieAPI.ModelTier
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public List<Movie>  Movies { get; set; }
    }
}
