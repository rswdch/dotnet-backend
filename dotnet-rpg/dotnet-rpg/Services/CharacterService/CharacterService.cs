using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private List<Character> mocks = new List<Character>
    {
        new Character{ Id=0, Name="Mock List"},
        new Character{ Id=1, Name="Second Mock"},
        new Character{ Id=2, Name="Third Mock"},
    };

    public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
    {
        mocks.Add(newCharacter);
        var serviceResponse = new ServiceResponse<List<Character>>();
        serviceResponse.Data = mocks;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        serviceResponse.Data = mocks;
        return serviceResponse;
    }

    public async Task<ServiceResponse<Character>> GetCharacterById(int id)
    {
        var result = mocks.Find(c => c.Id == id);
        // var result = (
        //     from mock in mocks
        //     where mock.Id == id
        //     select mock)
        //     .FirstOrDefault();
        var serviceResponse = new ServiceResponse<Character>();
        if (result is null)
        {
            serviceResponse.Data = null;
            serviceResponse.Success = false;
            serviceResponse.Message = "No character was found with that ID";
        }
        else
        {
            serviceResponse.Data = result;
        }
        return serviceResponse;
    }
}