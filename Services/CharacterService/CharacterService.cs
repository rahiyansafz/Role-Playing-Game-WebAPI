using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using RPGWebAPI.Data;
using RPGWebAPI.Dtos;
using RPGWebAPI.Models;

namespace RPGWebAPI.Services;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));
    private string GetUserRole() => _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Role);

    public async Task<ServiceResponse<IEnumerable<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
    {
        ServiceResponse<IEnumerable<GetCharacterDto>> serviceResponse = new();
        Character addCharacter = _mapper.Map<Character>(character);
        addCharacter.User = (await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId()))!;
        await _context.Characters!.AddAsync(addCharacter);
        await _context.SaveChangesAsync();
        serviceResponse.Data = (_context.Characters.Where(c => c.User!.Id == GetUserId()).Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
        serviceResponse.Count = serviceResponse.Data.Count();
        serviceResponse.Type = "Character";
        serviceResponse.Method = "POST";
        serviceResponse.Operation = "Add a character.";
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(Guid id)
    {
        ServiceResponse<GetCharacterDto> serviceResponse = new();
        Character dbCharacter = (await _context.Characters!.Include(c => c.Weapon).Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill).FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId()))!;
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
        if (serviceResponse.Data is not null) serviceResponse.Count = 1;
        serviceResponse.Type = "Character";
        serviceResponse.Method = "GET";
        serviceResponse.Operation = "Get a character.";
        return serviceResponse;
    }

    public async Task<ServiceResponse<IEnumerable<GetCharacterDto>>> GetAllCharacters()
    {
        ServiceResponse<IEnumerable<GetCharacterDto>> serviceResponse = new();
        IEnumerable<Character> dbCharacters = GetUserRole().Equals("Admin") ? await _context.Characters.ToListAsync() : await _context.Characters!.Where(c => c.User!.Id == GetUserId()).ToListAsync();
        serviceResponse.Data = (dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
        serviceResponse.Count = dbCharacters.Count();
        serviceResponse.Type = "Character";
        serviceResponse.Method = "GET";
        serviceResponse.Operation = "Get all characters.";
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        ServiceResponse<GetCharacterDto> serviceResponse = new();
        try
        {
            Character character = (await _context.Characters!.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id))!;

            if (character.User!.Id == GetUserId())
            {
                character.Name = updatedCharacter.Name;
                character.Class = updatedCharacter.Class;
                character.Defense = updatedCharacter.Defense;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Strength = updatedCharacter.Strength;

                _context.Characters!.Update(character);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                if (serviceResponse.Data is not null) serviceResponse.Count = 1;
                serviceResponse.Type = "Character";
                serviceResponse.Method = "PUT";
                serviceResponse.Operation = "Update a character.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character not found!";
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<IEnumerable<GetCharacterDto>>> DeleteCharacter(Guid id)
    {
        ServiceResponse<IEnumerable<GetCharacterDto>> serviceResponse = new();
        try
        {
            Character character = (await _context.Characters!.FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId()))!;
            if (character is not null)
            {
                _context.Characters!.Remove(character);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Characters.Where(c => c.User!.Id == GetUserId()).Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
                serviceResponse.Count = serviceResponse.Data.Count();
                serviceResponse.Type = "Character";
                serviceResponse.Method = "DELETE";
                serviceResponse.Operation = "Remove a character.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character not found!";
            }

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
