using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Responses;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface ICategoryService
    {
        public Task<DataResponse<Category>> AddAsync(Category category);
        public Task<DataResponse<IEnumerable<Category>>> GetAll(bool track=true);
        public Response RemoveById(int id);
        public bool Remove(Category category);
        public bool Update(Category category);
    }
}
