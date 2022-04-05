using AutoMapper;
using RPGWebAPI.Dtos;
using RPGWebAPI.Dtos.Skill;
using RPGWebAPI.Dtos.Weapon;
using RPGWebAPI.Models;

namespace RPGWebAPI;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterDto>().ForMember(dto => dto.Skills, c => c.MapFrom(c => c.CharacterSkills.Select(cs => cs.Skill)));
        CreateMap<AddCharacterDto, Character>();
        CreateMap<Weapon, GetWeaponDto>();
        CreateMap<Skill, GetSkillDto>();
    }
}
