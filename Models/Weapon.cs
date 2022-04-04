namespace RPGWebAPI.Models;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }

    public Guid CharacterId { get; set; }
    public Character Character { get; set; } = null!;
}
