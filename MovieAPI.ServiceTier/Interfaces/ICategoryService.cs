using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.Entities;

namespace MovieAPI.ServiceTier.Interfaces
{
    public interface ICategoryService
    {
        public Task<bool> AddAsync(Category category);
        public Task<IEnumerable<Category>> GetAll(bool track=true);
        public bool RemoveById(int id);
        public bool Remove(Category category);
        public bool Update(Category category);
    }
}
