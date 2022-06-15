using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.ServiceTier.Responses;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface IManagerService
    {
        public Task<DataResponse<IEnumerable<Manager>>> ManagersByAgeGreater(int age);
        public Task<DataResponse<IEnumerable<Manager>>> ManagersByAgeLess(int age);
        public Task<DataResponse<Manager>> AddAsync(SaveManagerDto manager);
        public Task<DataResponse<IEnumerable<Manager>>> GetAll();
        public Task<Response> RemoveByIdAsync(int id);
        public bool Remove(Manager manager);
        public Response Update(Manager manager);
       
    }
}
