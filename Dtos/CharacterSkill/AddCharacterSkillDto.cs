namespace RPGWebAPI.Dtos.CharacterSkill;

public class AddCharacterSkillDto
{
    public Guid CharacterId { get; set; }
    public int SkillId { get; set; }
}
