using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using dotnet_rpg.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService service)
        {
            _characterService = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> GetAsync()
        {
            var result = await _characterService.GetAllCharacters();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetAsync(int id)
        {
            var result = await _characterService.GetCharacterById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Post(Character newChar)
        {
            var result = await _characterService.AddCharacter(newChar);
            return Ok(result.Data);
        }
    }
}
