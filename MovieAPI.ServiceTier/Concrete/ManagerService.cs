using AutoMapper;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos;
using MovieAPI.ServiceTier.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAPI.ServiceTier.Responses;

namespace MovieAPI.ServiceTier.Concrete
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository m_managerRepository;
        private readonly IMapper m_mapper;
        public ManagerService(IManagerRepository managerRepository, IMapper mapper)
        {
            m_mapper = mapper;
            m_managerRepository = managerRepository;
        }
        public async Task<DataResponse<Manager>> AddAsync(SaveManagerDto manager)
        {
            var addmanager = m_mapper.Map<Manager>(manager);
            return new DataResponse<Manager>(true,"Başarıyla Eklendi.", addmanager);
        }

        public async Task<DataResponse<IEnumerable<Manager>>> GetAll()
        {
            var managers = await m_managerRepository.GetAllAsync();
            return new DataResponse<IEnumerable<Manager>>(true, managers);
        }
        public async Task<DataResponse<IEnumerable<Manager>>> ManagersByAgeGreater(int age)
        {
            var managers = await m_managerRepository.ManagersByAgeGreater(age);
            return new DataResponse<IEnumerable<Manager>>(true, managers);
        }

        public async Task<DataResponse<IEnumerable<Manager>>> ManagersByAgeLess(int age)
        {
            var managers = await m_managerRepository.ManagersByAgeLess(age);
            return new DataResponse<IEnumerable<Manager>>(true, managers);
        }

        public async Task<Response> RemoveByIdAsync(int id)
        {
            var manager = await m_managerRepository.GetByIdAsync(id);
            if (manager==null)
            {
                return new Response(false, "id' ye sahip manager bulunamadı");
            }

            m_managerRepository.DeleteByIdAsync(id);
            return new Response(true, "Basarıyla Silindi");
        }

        public bool Remove(Manager manager)
        {
            return m_managerRepository.Delete(manager);
        }

        public  Response Update(Manager manager)
        {
             m_managerRepository.Update(manager);
             return new Response(true, "basarıyla güncellendi");
        }


    }
}
