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
            return new ObjectResult(await m_managerService.ManagersByAgeGreater(age));
        }
        [HttpPost("save")]
        public async Task<IActionResult> Save(SaveManagerDto manager)
        {
            return new ObjectResult(await m_managerService.AddAsync(manager));
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return new ObjectResult(await m_managerService.GetAll());
        }

        [HttpDelete("removebyid")]
        public IActionResult RemoveById(int id)
        {
            return new ObjectResult(m_managerService.RemoveByIdAsync(id));
        }
        [HttpPost("remove")]
        public IActionResult Remove(Manager manager)
        {
            return new ObjectResult(m_managerService.Remove(manager));
        }

        [HttpPut("update")]
        public IActionResult Update(Manager manager)
        {
            return new ObjectResult(m_managerService.Update(manager));
        }

    }
}
