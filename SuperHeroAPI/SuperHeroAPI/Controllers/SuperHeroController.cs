using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
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
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null) return NotFound($@"No hero found with that id {id}");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero hero)
        {
            var heroToUpdate = superHeroes.Find(hero => hero.Id == id);
            if (heroToUpdate is null)
            {
                return BadRequest("Hero not found");
            }

            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.LastName = hero.LastName;
            heroToUpdate.Place = hero.Place;
            return superHeroes;
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroToUpdate = superHeroes.Find(hero => hero.Id == id);
            if (heroToUpdate is null)
            {
                return BadRequest("Hero not found");
            }
            superHeroes.Remove(heroToUpdate); return Ok(superHeroes);

        }

    }
}
