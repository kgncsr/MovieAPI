using AutoMapper;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos;
using MovieAPI.ServiceTier.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Concrete
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository m_managerRepository;
        private readonly IMapper m_mapper; 
        public ManagerService(IManagerRepository managerRepository,IMapper mapper)
        {
           m_mapper = mapper;
           m_managerRepository = managerRepository;
        }

        public async Task<bool> AddAsync(SaveManagerDto manager)
        {
            var addmanager = m_mapper.Map<Manager>(manager);
            return await m_managerRepository.AddAsync(addmanager);
        }

        public async Task<IEnumerable<Manager>> GetAll()
        {
            return await m_managerRepository.GetAllAsync();
        }

        public bool RemoveByIdAsync(int id)
        {
            return m_managerRepository.DeleteByIdAsync(id);
        }

        public bool Remove(Manager manager)
        {
            return m_managerRepository.Delete(manager);
        }

        public bool Update(Manager manager)
        {
          return  m_managerRepository.Update(manager);
        }

        public Task<IEnumerable<Manager>> ManagersByAgeGreater(int age)
        {
           return m_managerRepository.ManagersByAgeGreater(age);
        }

        public Task<IEnumerable<Manager>> ManagersByAgeLess(int age)
        {
            return m_managerRepository.ManagersByAgeLess(age);
        }
    }
}
