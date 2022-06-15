using Microsoft.AspNetCore.Mvc;
using MovieAPI.ServiceTier.Dtos;
using MovieAPI.ServiceTier.Interfaces;
using System.Threading.Tasks;
using MovieAPI.Entities;

namespace MovieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService m_managerService;
        public ManagersController(IManagerService managerService)
        {
            m_managerService = managerService;
        }
        [HttpGet("find/manager/age")]
        public async Task<IActionResult> ManagersByAgeGreater(int age)
        {
            var result = await m_managerService.ManagersByAgeGreater(age);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpPost("save")]
        public async Task<IActionResult> Save(SaveManagerDto manager)
        {
            var saveresult = await m_managerService.AddAsync(manager);
            return new ObjectResult(saveresult);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return new ObjectResult(await m_managerService.GetAll());
        }

        [HttpDelete("removebyid")]
        public async Task<IActionResult> RemoveById(int id)
        {
            var result = await m_managerService.RemoveByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("remove")]
        public IActionResult Remove(Manager manager)
        {
            return new ObjectResult(m_managerService.Remove(manager));
        }

        [HttpPut("update")]
        public IActionResult Update(Manager manager)
        {
            var result = m_managerService.Update(manager);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    }
}
