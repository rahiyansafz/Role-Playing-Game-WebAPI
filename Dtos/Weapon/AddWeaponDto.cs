namespace RPGWebAPI.Dtos.Weapon;

public class AddWeaponDto
{
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }

    public Guid CharacterId { get; set; }
}
