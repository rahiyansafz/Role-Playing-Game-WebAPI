using Microsoft.EntityFrameworkCore;
using RPGWebAPI.Data;
using RPGWebAPI.Dtos.Fight;
using RPGWebAPI.Models;

namespace RPGWebAPI.Services.FightService;

public class FightService : IFightService
{
    private readonly DataContext _context;

    public FightService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
    {
        ServiceResponse<AttackResultDto> response = new();
        try
        {
            Character attacker = (await _context.Characters.Include(c => c.Weapon).FirstOrDefaultAsync(c => c.Id == request.AttackerId))!;
            Character opponent = (await _context.Characters.FirstOrDefaultAsync(c => c.Id == request.OpponentId))!;

            int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
            damage -= new Random().Next(opponent.Defense);

            if (damage > 0) opponent.HitPoints -= damage;

            if (opponent.HitPoints <= 0) response.Message = $"{opponent.Name} has been defeated!";

            _context.Characters.Update(opponent);
            await _context.SaveChangesAsync();

            response.Data = new AttackResultDto
            {
                Attacker = attacker.Name,
                AttackerHP = attacker.HitPoints,
                Opponent = opponent.Name,
                OpponentHP = opponent.HitPoints,
                Damage = damage
            };
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}
