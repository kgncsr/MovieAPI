using Microsoft.AspNetCore.Mvc;
using MovieAPI.ServiceTier.Dtos.User;
using MovieAPI.ServiceTier.Interfaces;
using MovieAPI.ServiceTier.Responses;
using System.Threading.Tasks;

namespace MovieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class AuthController : Controller
    {
        private readonly IAuthService m_authService;

        public AuthController(IAuthService authService)
        {
            m_authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDxto)
        {
            var result = await m_authService.LoginAsync(userLoginDxto);
            return Ok(result.Data);
             
        }


        [HttpPost("register")]
        public IActionResult CreateUser(UserRegisterDto user)
        {
            
            return View();
        }
    }
}
