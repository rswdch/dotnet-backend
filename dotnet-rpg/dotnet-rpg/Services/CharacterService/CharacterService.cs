using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> mocks = new List<Character>
    {
        new Character{ Id=0, Name="Mock List"},
        new Character{ Id=1, Name="Second Mock"},
        new Character{ Id=2, Name="Third Mock"},
    };
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CharacterService(IMapper mapper, DataContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var newCharToSetId = _mapper.Map<Character>(newCharacter);
        //newCharToSetId.Id = mocks.Max(c => c.Id)+1;
        //mocks.Add(_mapper.Map<Character>(newCharToSetId));

        // We do not need AddAsync because we are not making db query
        _context.Characters.Add(_mapper.Map<Character>(newCharToSetId));
        await _context.SaveChangesAsync();
        
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var newList = await GetAllCharacters();
        serviceResponse.Data = newList.Data;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var dbData = await _context.Characters.ToListAsync();
        serviceResponse.Data = dbData.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        //serviceResponse.Data = mocks.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        var result = _context.Characters.FirstOrDefault(c => c.Id == id);
        //var result = mocks.FirstOrDefault(c => c.Id == id);
        // var result = (
        //     from mock in mocks
        //     where mock.Id == id
        //     select mock)
        //     .FirstOrDefault();
        if (result is null)
        {
            serviceResponse.Data = null;
            serviceResponse.Success = false;
            serviceResponse.Message = "No character was found with that ID";
        }
        else
        {
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(result);
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(Character newCharacter)
    {
        try
        {
            var charToChange = mocks.FirstOrDefault(c => c.Id == newCharacter.Id);
            if (charToChange is null)
            {
                throw new Exception($"Unable to update: No character found with ID {newCharacter.Id}");
            }
            // AutoMapper, requires new map creation
            //_mapper.Map(newCharacter, charToChange);

            charToChange.Strength = newCharacter.Strength;
            charToChange.Defense = newCharacter.Defense;
            charToChange.Intelligence = newCharacter.Intelligence;
            charToChange.HitPoints = newCharacter.HitPoints;
            charToChange.Name = newCharacter.Name;
            charToChange.Class = newCharacter.Class;
            return new ServiceResponse<GetCharacterDto>
            {
                Data = _mapper.Map<GetCharacterDto>(mocks.FirstOrDefault(c => c.Id == newCharacter.Id)),
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<GetCharacterDto> { 
                Message = e.Message,
                Success = false };
        }
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacterById(int id)
    {
        try
        {
            var charToDelete = mocks.FirstOrDefault(c => c.Id == id);
            if (charToDelete is null)
            {
                throw new Exception($"Unable to update: No character found with ID {id}");
            }

            mocks.Remove(charToDelete);
            var newList = await GetAllCharacters();
            return new ServiceResponse<List<GetCharacterDto>>
            {
                Data = newList.Data,
                Message = $"Character with id {id} deleted",
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<List<GetCharacterDto>>
            {
                Message = e.Message,
                Success = false
            };
        }

    }
}