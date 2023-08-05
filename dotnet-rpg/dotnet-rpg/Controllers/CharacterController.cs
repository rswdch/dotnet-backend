using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using dotnet_rpg.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Dtos.Character;

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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAsync()
        {
            var result = await _characterService.GetAllCharacters();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetAsync(int id)
        {
            var result = await _characterService.GetCharacterById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Post(AddCharacterDto newChar)
        {
            var result = await _characterService.AddCharacter(newChar);
            return Ok(result.Data);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(Character changedChar)
        {
            var result = await _characterService.UpdateCharacter(changedChar);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var result = await _characterService.DeleteCharacterById(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
