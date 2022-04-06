namespace RPGWebAPI.Dtos.Fight;

public class FightRequestDto
{
    public List<Guid> CharacterIds { get; set; } = null!;
}
