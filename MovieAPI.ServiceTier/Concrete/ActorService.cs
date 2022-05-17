using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MovieAPI.ModelTier;
using MovieAPI.ServiceTier.Dtos.Actor;

namespace MovieAPI.ServiceTier.Concrete
{

    public class ActorService : IActorService
    {
        private readonly IActorRepository m_actorRepository;
        private readonly IMapper m_mapper;

        public ActorService(IActorRepository actorRepository, IMapper mMapper)
        {
            m_actorRepository = actorRepository;
            m_mapper = mMapper;
        }

        public async Task<IEnumerable<Actor>> GetActorByManAsync(string gender)
        {
            return await m_actorRepository.GetActorByManAsync(gender);
        }
        public async Task<bool> AddAsync(SaveActor actor)
        {
            var result = await m_actorRepository.AddAsync(m_mapper.Map<Actor>(actor));
            return result;
        }
        public async Task<IEnumerable<ActorDto>> GetAllActorsAsync()
        {
            var result = await m_actorRepository.GetAllAsync();
            var actors = result.Select(a => m_mapper.Map<ActorDto>(a));
            return actors;
        }
        public bool RemoveByIdAsync(int id)
        {
            return m_actorRepository.DeleteByIdAsync(id);
        }
        public bool Remove(Actor actor)
        {
            return m_actorRepository.Delete(actor);
        }
        public bool Update(UpdateActor actor)
        {
            return m_actorRepository.Update(m_mapper.Map<Actor>(actor));
        }
    }
}
