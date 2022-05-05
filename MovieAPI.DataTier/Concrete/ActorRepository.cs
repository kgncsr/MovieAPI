using Microsoft.EntityFrameworkCore;
using MovieAPI.DataTier.Context;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.ModelTier;

namespace MovieAPI.DataTier.Concrete
{
    public class ActorRepository : CrudRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieContext movieContext) : base(movieContext)
        {
        }
        private MovieContext movieContext { get { return _movieContext as MovieContext; } }
        #region callback
        public IEnumerable<Actor> getActorByManCallBack(string gender,bool track)
        {
            var actors = movieContext.Actors.Where(b => b.Gender.ToLower() == gender.ToLower());
            if (!track)
            {
                actors.AsNoTracking();
            }
            return actors;
        }
        #endregion


        public Task<IEnumerable<Actor>> GetActorByManAsync(string gender, bool track=true)
        {
            var task = new Task<IEnumerable<Actor>>(()=> getActorByManCallBack(gender,track));
            task.Start();
            return task;
        }

        public Task<IEnumerable<Actor>> GetActorByManAsync(string gender)
        {
            throw new NotImplementedException();
        }
    }
}
