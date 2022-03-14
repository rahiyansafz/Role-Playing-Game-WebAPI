using AutoMapper;
using WebApiJumpStart.Dtos;
using WebApiJumpStart.Models;

namespace WebApiJumpStart
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
