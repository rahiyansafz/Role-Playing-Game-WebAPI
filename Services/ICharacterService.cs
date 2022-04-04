using RPGWebAPI.Dtos;
using RPGWebAPI.Models;

namespace RPGWebAPI.Services;

public interface ICharacterService
{
    Task<ServiceResponse<IEnumerable<GetCharacterDto>>> GetAllCharacters();
    Task<ServiceResponse<GetCharacterDto>> GetCharacterById(Guid id);
    Task<ServiceResponse<IEnumerable<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
    Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
    Task<ServiceResponse<IEnumerable<GetCharacterDto>>> DeleteCharacter(Guid id);
}
