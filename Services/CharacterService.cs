using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiJumpStart.Data;
using WebApiJumpStart.Dtos;
using WebApiJumpStart.Models;

namespace WebApiJumpStart.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            ServiceResponse<IEnumerable<GetCharacterDto>> serviceResponse = new();
            Character addCharacter = _mapper.Map<Character>(character);
            await _context.Characters!.AddAsync(addCharacter);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            serviceResponse.Count = serviceResponse.Data.Count();
            serviceResponse.Type = "Character";
            serviceResponse.Method = "POST";
            serviceResponse.Operation = "Add a character.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(Guid id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new();
            Character dbCharacter = (await _context.Characters!.FirstOrDefaultAsync(c => c.Id == id))!;
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
            IEnumerable<Character> dbCharacters = await _context.Characters!.ToListAsync();
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
                Character character = (await _context.Characters!.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id))!;
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
                Character character = await _context.Characters!.FirstAsync(c => c.Id == id);
                _context.Characters!.Remove(character);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
                serviceResponse.Count = serviceResponse.Data.Count();
                serviceResponse.Type = "Character";
                serviceResponse.Method = "DELETE";
                serviceResponse.Operation = "Remove a character.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
