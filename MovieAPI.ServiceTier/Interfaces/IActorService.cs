using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.ModelTier;
using MovieAPI.ServiceTier.Dtos.Actor;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface IActorService
    {
        public Task<IEnumerable<Actor>> GetActorByManAsync(string gender);
        public Task<bool> AddAsync(SaveActor actor);
        public Task<IEnumerable<ActorDto>> GetAllActorsAsync();
        public bool RemoveByIdAsync(int id);
        public bool Remove(Actor actor);
        public bool Update(UpdateActor actor);

    }
}
