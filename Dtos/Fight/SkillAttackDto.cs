namespace RPGWebAPI.Dtos.Fight;

public class SkillAttackDto
{
    public Guid AttackerId { get; set; }
    public Guid OpponentId { get; set; }
    public int SkillId { get; set; }
}
