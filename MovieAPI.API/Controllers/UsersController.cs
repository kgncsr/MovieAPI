using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.ServiceTier.Dtos.User;
using MovieAPI.ServiceTier.Interfaces;

namespace MovieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService m_userService;

        public UsersController(IUserService UserService)
        {
            m_userService = UserService;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Authanticate(UserLoginDto userLogin)
        {
            var result = await m_userService.Authanticate(userLogin);
            return new ObjectResult(result);
        }
    }
}
