using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPGWebAPI.Data;
using RPGWebAPI.Dtos;
using RPGWebAPI.Dtos.CharacterSkill;
using RPGWebAPI.Models;
using System.Security.Claims;

namespace RPGWebAPI.Services.CharacterSkillService;

public class CharacterSkillService : ICharacterSkillService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public CharacterSkillService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
    {
        ServiceResponse<GetCharacterDto> response = new();
        try
        {
            Character character = (await _context.Characters.Include(c => c.Weapon).Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill).FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId && c.User.Id == int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier))))!;
            if (character is null)
            {
                response.Success = false;
                response.Message = "Character not found!";
                return response;
            }
            Skill skill = (await _context.Skills.FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId))!;

            if (skill is null)
            {
                response.Success = false;
                response.Message = "Skill not found!";
                return response;
            }
            CharacterSkill characterSkill = new CharacterSkill
            {
                Character = character,
                Skill = skill
            };

            await _context.CharacterSkills.AddAsync(characterSkill);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetCharacterDto>(character);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}
