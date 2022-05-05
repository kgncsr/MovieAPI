using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Dtos.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SceneDate { get; set; }
        public long? Rating { get; set; }
        public float? Imdb { get; set; }
        public decimal Cost { get; set; }
        public int? ManagerId { get; set; }

    }
}
