namespace RPGWebAPI.Models;

public class CharacterSkill
{
    public Guid CharacterId { get; set; }
    public Character Character { get; set; } = null!;

    public int SkillId { get; set; }
    public Skill Skill { get; set; } = null!;
}
