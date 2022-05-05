using Microsoft.AspNetCore.Mvc;
using MovieAPI.ServiceTier.Interfaces;
using System.Threading.Tasks;
using MovieAPI.Entities;
using MovieAPI.ModelTier;
using MovieAPI.ServiceTier.Dtos.Actor;

namespace MovieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService m_actorService;
        public ActorsController(IActorService actorService)
        {
            m_actorService = actorService;
        }
        [HttpGet("find/actors/gender")]
        public async Task<IActionResult> GetActorsByGender(string gender)
        {
            return  new ObjectResult(await m_actorService.GetActorByManAsync(gender));
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllActors()
        {
            return new ObjectResult(await m_actorService.GetAllActorsAsync());
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(SaveActor actor)
        {
            return new ObjectResult(await m_actorService.AddAsync(actor));
        }

        [HttpDelete("removebyid")]
        public IActionResult RemoveById(int id)
        {
            return new ObjectResult(m_actorService.RemoveByIdAsync(id));
        }

        [HttpPost("remove")]
        public IActionResult Remove(Actor actor)
        {
            return new ObjectResult( m_actorService.Remove(actor));
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateActor actor)
        {
            return new ObjectResult(m_actorService.Update(actor));
        }


    }
}
