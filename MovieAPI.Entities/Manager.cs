using MovieAPI.Entities.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Entities
{
    public class Manager : BaseEntity
    {     
        public DateTime BirthDate { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
