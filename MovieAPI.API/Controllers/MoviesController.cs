using Microsoft.AspNetCore.Mvc;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos.Movie;
using MovieAPI.ServiceTier.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        [HttpPost("save")]
        public async Task<IActionResult> Save(MovieCreateDto movie)
        {
            return new ObjectResult(await m_movieService.AddAsync(movie));
        }
        [HttpPost("saverange")]
        public async Task<IActionResult> SaveRange(List<Movie> movies)
        {

            return new ObjectResult(await m_movieService.AddRangeAsync(movies));
        }
        [HttpGet("find/manager")]
        public async Task<IActionResult> FindMoviesByManagerId(int id)
        {
            return new ObjectResult(await m_movieService.FindMoviesByManagerId(id));
        }
        [HttpGet("find/year")]
        public async Task<IActionResult> FindYearAsync(int year)
        {
            return new ObjectResult(await m_movieService.FindByYearAsync(year));
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMovieAsync()
        {
            var result = await m_movieService.GetAllAsync();
            return new ObjectResult(result.ToList());
        }
        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
        {
            return new ObjectResult(await m_movieService.GetCountAsync());
        }
        [HttpGet("find/movie")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            return new ObjectResult(await m_movieService.GetByIdAsync(id));
        }
        [HttpDelete("delete")]
        public  IActionResult Delete(int id)
        {
            return new ObjectResult( m_movieService.DeleteById(id));
        }
        [HttpGet("find/sum")]
        public async Task<decimal> FindSumYearAsync(int year)
        {
            return await m_movieService.FindSumYearAsync(year);
        }
        [HttpGet("find/ımdb")]
        public async Task<IActionResult> MoviesByImdbGreaterOrderBy(long imdb)
        {
            return new ObjectResult(await m_movieService.MoviesByImdbGreaterOrderBy(imdb));
        }
        [HttpPut("update")]
        public IActionResult Update(MovieUpdateDto movie)
        {
            return new ObjectResult(m_movieService.Update(movie));
        }

    }
}
