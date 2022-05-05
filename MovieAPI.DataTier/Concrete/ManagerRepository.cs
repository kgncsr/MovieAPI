using Microsoft.EntityFrameworkCore;
using MovieAPI.DataTier.Context;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.DataTier.Concrete
{
    public class ManagerRepository : CrudRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(MovieContext movieContext) : base(movieContext)
        {
        }
        private MovieContext movieContext { get { return _movieContext as MovieContext; } }

        private IEnumerable<Manager> managersByAgeGreaterCallBack(int age,bool track)
        {
            var query = movieContext.Managers.Where(a => (DateTime.Today.Date-a.BirthDate.Date).TotalDays/365>age);

            if (!track)
            {
                query.AsNoTracking();
            }
            return query.AsEnumerable();
        }
        private IEnumerable<Manager> managersByAgeLessCallBack(int age, bool track)
        {
            var query = movieContext.Managers.Where(a => ((DateTime.Today - a.BirthDate).TotalDays / 365) < age);

            if (!track)
            {
                query.AsNoTracking();
            }
            return query.AsEnumerable();
        }


        public Task<IEnumerable<Manager>> ManagersByAgeGreater(int age,bool track=true)
        {
            var task = new Task<IEnumerable<Manager>>(() => managersByAgeGreaterCallBack(age,track));
            task.Start();
            return task;
        }

        public Task<IEnumerable<Manager>> ManagersByAgeLess(int age, bool track = true)
        {

            var task = new Task<IEnumerable<Manager>>(() => managersByAgeLessCallBack(age, track));
            task.Start();
            return task;
        }

    }
}
