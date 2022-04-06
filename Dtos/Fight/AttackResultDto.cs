namespace RPGWebAPI.Dtos.Fight;

public class AttackResultDto
{
    public string Attacker { get; set; } = null!;
    public string Opponent { get; set; } = null!;
    public int AttackerHP { get; set; }
    public int OpponentHP { get; set; }
    public int Damage { get; set; }
}
