using MovieAPI.Entities.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Entities
{
    public class Movie : BaseEntity
    {
        public DateTime SceneDate { get; set; }
        public decimal Cost { get; set; }
        public int Rating { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Category> Categories { get; set; }
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }

    }
}
