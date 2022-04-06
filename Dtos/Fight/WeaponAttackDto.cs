namespace RPGWebAPI.Dtos.Fight;

public class WeaponAttackDto
{
    public Guid AttackerId { get; set; }
    public Guid OpponentId { get; set; }
}
