using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Interfaces;

namespace MovieAPI.ServiceTier.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository m_categoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository)
        {
            m_categoryRepository = CategoryRepository;
        }

        public async Task<bool> AddAsync(Category category)
        {
            return await m_categoryRepository.AddAsync(category);
        }
        public async Task<IEnumerable<Category>> GetAll(bool track=true)
        {
            return await m_categoryRepository.GetAllAsync(track);
        }

        public bool RemoveById(int id)
        {
            return m_categoryRepository.DeleteByIdAsync(id);
        }

        public bool Remove(Category category)
        {
            return m_categoryRepository.Delete(category);
        }

        public bool Update(Category category)
        {
            return  m_categoryRepository.Update(category);  
        }
    }
}
