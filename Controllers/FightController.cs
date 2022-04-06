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
}
