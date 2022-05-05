using MovieAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAPI.ModelTier;

namespace MovieAPI.DataTier.Interfaces
{

    public interface IActorRepository : ICrudRepository<Actor>
    {
        public Task<IEnumerable<Actor>> GetActorByManAsync(string gender);

    }
}
