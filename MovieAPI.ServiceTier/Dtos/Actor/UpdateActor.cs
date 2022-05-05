using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.Entities.Cammon;

namespace MovieAPI.ServiceTier.Dtos.Actor
{
    public class UpdateActor : BaseEntity
    {
        public string Country { get; set; }
        public string Gender { get; set; }
    }
}
