namespace RPGWebAPI.Dtos.Fight;

public class HighscoreDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Fights { get; set; }
    public int Victories { get; set; }
    public int Defeats { get; set; }
}
