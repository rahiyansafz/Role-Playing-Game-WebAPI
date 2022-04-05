using Microsoft.EntityFrameworkCore;
using RPGWebAPI.Models;

namespace RPGWebAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Weapon> Weapons { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<CharacterSkill> CharacterSkills { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CharacterSkill>().HasKey(cs=> new { cs.CharacterId, cs.SkillId });
    }
}
