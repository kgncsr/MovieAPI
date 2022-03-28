using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.ServiceTier.Interfaces;

namespace MovieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService m_movieService;
        public MoviesController(IMovieService movieService)
        {
            m_movieService = movieService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllMovie()
        {
           return Ok( m_movieService.GetAllAsync());
        }
    }
}
