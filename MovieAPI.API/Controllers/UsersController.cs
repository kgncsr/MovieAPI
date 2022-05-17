using Microsoft.AspNetCore.Mvc;
using MovieAPI.ServiceTier.Interfaces;
using System.Threading.Tasks;

namespace MovieAPI.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService m_userService;

        public UsersController(IUserService userService)
        {
            m_userService = userService;
        }
        [HttpGet("find/userbyid")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await m_userService.GetUserByIdAsync(id,false);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("find/userbyname")]
        public async Task<IActionResult> GetUserByNameAsync(string name)
        {
            var result = await m_userService.GetUserByUserName(name, false);
            return new ObjectResult(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> AlLUsers()
        {
            return new ObjectResult(await m_userService.AllUser());
        }
    }
}
