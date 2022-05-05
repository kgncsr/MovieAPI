using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface IManagerService
    {
        public Task<IEnumerable<Manager>> ManagersByAgeGreater(int age);
        public Task<IEnumerable<Manager>> ManagersByAgeLess(int age);
        public Task<bool> AddAsync(SaveManagerDto manager);
        public Task<IEnumerable<Manager>> GetAll();
        public bool RemoveByIdAsync(int id);
        public bool Remove(Manager manager);
        public bool Update(Manager manager
        );
    }
}
