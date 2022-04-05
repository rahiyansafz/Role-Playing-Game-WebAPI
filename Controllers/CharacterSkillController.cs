using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPGWebAPI.Dtos.CharacterSkill;
using RPGWebAPI.Services.CharacterSkillService;

namespace RPGWebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CharacterSkillController : ControllerBase
{
    private readonly ICharacterSkillService _characterSkillService;

    public CharacterSkillController(ICharacterSkillService characterSkillService)
    {
        _characterSkillService = characterSkillService;
    }

    [HttpPost]
    public async Task<ActionResult> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
    {
        return Ok(await _characterSkillService.AddCharacterSkill(newCharacterSkill));
    }
}
