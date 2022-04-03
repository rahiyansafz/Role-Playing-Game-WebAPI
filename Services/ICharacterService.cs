using WebApiJumpStart.Dtos;
using WebApiJumpStart.Models;

namespace WebApiJumpStart.Services;

public interface ICharacterService
{
    Task<ServiceResponse<IEnumerable<GetCharacterDto>>> GetAllCharacters(int userId);
    Task<ServiceResponse<GetCharacterDto>> GetCharacterById(Guid id);
    Task<ServiceResponse<IEnumerable<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
    Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
    Task<ServiceResponse<IEnumerable<GetCharacterDto>>> DeleteCharacter(Guid id);
}
