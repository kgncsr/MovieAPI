using MovieAPI.Entities.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieAPI.Entities
{
    public class Category : BaseEntity
    {
        public List<Movie> Movies { get; set; }
    }
}
