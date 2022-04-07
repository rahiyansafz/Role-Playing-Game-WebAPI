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
        modelBuilder.Entity<CharacterSkill>().HasKey(cs => new { cs.CharacterId, cs.SkillId });

        modelBuilder.Entity<User>().Property(user => user.Role).HasDefaultValue("Player");


        modelBuilder.Entity<Skill>().HasData(
                        new Skill { Id = 1, Name = "Fireball", Damage = 30 },
                        new Skill { Id = 2, Name = "Frenzy", Damage = 20 },
                        new Skill { Id = 3, Name = "Blizzard", Damage = 50 }
                        );

        Utility.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "User1" },
            new User { Id = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "User2" }
            );

        modelBuilder.Entity<Character>().HasData(
                 new Character
                 {
                     Id = Guid.NewGuid(),
                     Name = "Frodo",
                     Class = RpgClass.Knight,
                     HitPoints = 100,
                     Strength = 15,
                     Defense = 10,
                     Intelligence = 10,
                     UserId = 1
                 },
                new Character
                {
                    Id = Guid.NewGuid(),
                    Name = "Raistlin",
                    Class = RpgClass.Mage,
                    HitPoints = 100,
                    Strength = 5,
                    Defense = 5,
                    Intelligence = 20,
                    UserId = 2
                }
                );

        modelBuilder.Entity<Weapon>().HasData(
            new Weapon { Id = 1, Name = "The Master Sword", Damage = 20, CharacterId = Guid.NewGuid() },
            new Weapon { Id = 2, Name = "Crystal Wand", Damage = 5, CharacterId = Guid.NewGuid() }
            );

        modelBuilder.Entity<CharacterSkill>().HasData(
              new CharacterSkill { CharacterId = Guid.NewGuid(), SkillId = 2 },
              new CharacterSkill { CharacterId = Guid.NewGuid(), SkillId = 1 },
              new CharacterSkill { CharacterId = Guid.NewGuid(), SkillId = 3 }
            );

    }

}
