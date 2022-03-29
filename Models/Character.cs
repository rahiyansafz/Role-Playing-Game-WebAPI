using System.ComponentModel.DataAnnotations;

namespace WebApiJumpStart.Models;

public class Character
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "Hinayana";

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    //public DateTime PublishedAt { get; set; } = Convert.ToDateTime(DateTime.Now);

    public int HitPoints { get; set; } = 100;

    public int Strength { get; set; } = 10;

    public int Defense { get; set; } = 10;

    public int Intelligence { get; set; } = 10;

    public RpgClass Class { get; set; } = RpgClass.Ironman;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
