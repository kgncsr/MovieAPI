using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Interfaces;

namespace MovieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService m_categoryService;

        public CategoriesController(ICategoryService CategoryService)
        {
            m_categoryService = CategoryService;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Add(Category category)
        {
            var result = await m_categoryService.AddAsync(category);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await m_categoryService.GetAll();
            if (categories.Success)
            {
                return Ok(categories.Data);
            }
            return BadRequest(m_categoryService.GetAll().Result.Message);

        }

        [HttpDelete("removebyid")]
        public IActionResult RemoveById(int id)
        {
            var result = m_categoryService.RemoveById(id);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
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
