using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Interfaces;

namespace MovieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private  readonly  ICategoryService m_categoryService;

        public CategoriesController(ICategoryService CategoryService)
        {
            m_categoryService = CategoryService;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Add(Category category)
        {
            return new ObjectResult(await  m_categoryService.AddAsync(category));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return new ObjectResult(await m_categoryService.GetAll());
        }

        [HttpDelete("removebyid")]
        public IActionResult RemoveById(int id)
        {
            return new ObjectResult(m_categoryService.RemoveById(id));
        }

        [HttpPost("remove")]
        public IActionResult Remove(Category category)
        {
            return new ObjectResult(m_categoryService.Remove(category));
        }

        [HttpPut("update")]
        public IActionResult Update(Category category)
        {
            return new ObjectResult(m_categoryService.Update(category));
        }
    }
}
