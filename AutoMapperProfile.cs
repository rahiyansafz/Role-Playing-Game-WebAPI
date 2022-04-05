using AutoMapper;
using RPGWebAPI.Dtos;
using RPGWebAPI.Dtos.Weapon;
using RPGWebAPI.Models;

namespace RPGWebAPI;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterDto>();
        CreateMap<AddCharacterDto, Character>();
        CreateMap<Weapon, GetWeaponDto>();
    }
}
