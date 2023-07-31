using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name="Spider Man",
                    FirstName="Peter",
                    LastName="Parker",
                    Place = "New York City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name="Iron Man",
                    FirstName="Tony",
                    LastName="Stark",
                    Place = "Malibu"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _superHeroService.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _superHeroService.GetHero(id);
            if (hero is null) return NotFound($@"No hero found with that id {id}");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero hero)
        {
            var result = await _superHeroService.UpdateHero(id, hero);
            if (result is null)
            {
                return BadRequest("Hero not found");
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = _superHeroService.DeleteHero(id);
            if (result is null)
            {
                return BadRequest("Hero not found");
            }
            return Ok(result);

        }

    }
}
