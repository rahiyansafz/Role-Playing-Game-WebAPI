using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPGWebAPI.Dtos.Fight;
using RPGWebAPI.Services.FightService;

namespace RPGWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FightController : ControllerBase
{
    private readonly IFightService _fightService;

    public FightController(IFightService fightService)
    {
        _fightService = fightService;
    }

    [HttpPost("Weapon")]
    public async Task<ActionResult> WeaponAttack(WeaponAttackDto request)
    {
        return Ok(await _fightService.WeaponAttack(request));
    }

    [HttpPost("Skill")]
    public async Task<ActionResult> SkillAttack(SkillAttackDto request)
    {
        return Ok(await _fightService.SkillAttack(request));
    }

    [HttpPost]
    public async Task<ActionResult> Fight(FightRequestDto request)
    {
        return Ok(await _fightService.Fight(request));
    }

    public async Task<IActionResult> GetHighscore()
    {
        return Ok(await _fightService.GetHighscore());
    }
}
