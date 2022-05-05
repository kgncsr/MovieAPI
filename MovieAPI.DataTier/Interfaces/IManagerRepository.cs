using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataTier.Interfaces
{
    public interface IManagerRepository : ICrudRepository<Manager>
    {
        Task<IEnumerable<Manager>> ManagersByAgeGreater(int age, bool track = true);
        Task<IEnumerable<Manager>> ManagersByAgeLess(int age,bool track=true);
    }
}
