using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiJumpStart.Dtos;
using WebApiJumpStart.Models;
using WebApiJumpStart.Services;

namespace WebApiJumpStart.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [AllowAnonymous]
    //[HttpGet("GetCharacters")]
    [HttpGet(Name = "GetCharacters")]
    public async Task<ActionResult> Get()
    {
        int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
        return Ok(await _characterService.GetAllCharacters(userId));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    public async Task<ActionResult> AddCharacter(AddCharacterDto character)
    {
        return Ok(await _characterService.AddCharacter(character));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updatedCharacter);
        if (response.Data is null) NotFound(response);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCharacter(Guid id)
    {
        ServiceResponse<IEnumerable<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
        if (response.Data is null) NotFound(response);
        return Ok(response);
    }
}
