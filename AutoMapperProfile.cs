using AutoMapper;
using RPGWebAPI.Dtos;
using RPGWebAPI.Models;

namespace RPGWebAPI;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterDto>();
        CreateMap<AddCharacterDto, Character>();
    }
}
