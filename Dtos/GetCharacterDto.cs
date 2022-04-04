using RPGWebAPI.Models;
using WebApiJumpStart.Models;

namespace WebApiJumpStart.Dtos;

public class GetCharacterDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "Hinayana";

    public DateTime PublishedAt { get; set; } = Convert.ToDateTime(DateTime.Now);

    public int HitPoints { get; set; } = 100;

    public int Strength { get; set; } = 10;

    public int Defense { get; set; } = 10;

    public int Intelligence { get; set; } = 10;

    public RpgClass Class { get; set; } = RpgClass.Wizard;

    public int UserId { get; set; }

    //public int WeaponId { get; set; }
    public Weapon Weapon { get; set; } = null!;

}
