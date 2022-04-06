using RPGWebAPI.Dtos.Skill;
using RPGWebAPI.Dtos.Weapon;
using RPGWebAPI.Models;

namespace RPGWebAPI.Dtos;

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
    public GetWeaponDto Weapon { get; set; } = null!;
    public List<GetSkillDto> Skills { get; set; } = null!;
    public int Fights { get; set; }
    public int Victories { get; set; }
    public int Defeats { get; set; }

}
