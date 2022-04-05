using RPGWebAPI.Models;

namespace RPGWebAPI.Dtos;

public class UpdateCharacterDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "Hinayana";

    public int HitPoints { get; set; } = 100;

    public int Strength { get; set; } = 10;

    public int Defense { get; set; } = 10;

    public int Intelligence { get; set; } = 10;

    public RpgClass Class { get; set; } = RpgClass.Wizard;

    public int UserId { get; set; }

    //public int WeaponId { get; set; }
    //public Weapon Weapon { get; set; } = null!;

}
