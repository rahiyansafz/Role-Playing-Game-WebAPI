using RPGWebAPI.Dtos;
using RPGWebAPI.Dtos.CharacterSkill;
using RPGWebAPI.Models;

namespace RPGWebAPI.Services.CharacterSkillService;

public interface ICharacterSkillService
{
    Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
}
