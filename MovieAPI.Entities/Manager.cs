using MovieAPI.Entities.Cammon;
using System;
using System.Collections.Generic;

#nullable disable
namespace MovieAPI.Entities
{
    public  class Manager : BaseEntity
    {
        public DateTime BirthDate { get; set; }
        public List<Movie> Movies { get; set; }
    }
}

