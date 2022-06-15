using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.DataTier.Interfaces;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Interfaces;
using MovieAPI.ServiceTier.Responses;

namespace MovieAPI.ServiceTier.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository m_categoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository)
        {
            m_categoryRepository = CategoryRepository;
        }

        public async Task<DataResponse<Category>> AddAsync(Category category)
        {
            var result =   await m_categoryRepository.AddAsync(category);
            if (result)
            {
                return new DataResponse<Category>(true,"Basarıyla eklendi", category);
            }
            return new DataResponse<Category>(false,"başarısız oldu", category);
        }
        public async Task<DataResponse<IEnumerable<Category>>> GetAll(bool track=true)
        {
            var all = await m_categoryRepository.GetAllAsync();
            return new DataResponse<IEnumerable<Category>>(true, all);
        }

        public Response RemoveById(int id)
        {
            var category =  m_categoryRepository.GetByIdAsync(id).Result;
            if (category == null)
            {
                return new Response(false, "id' ye sahip category bulunamadı");
            }

            m_categoryRepository.DeleteByIdAsync(id);
            return new Response(true, "Basarıyla Silindi");
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
