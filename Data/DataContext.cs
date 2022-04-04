using Microsoft.EntityFrameworkCore;
using RPGWebAPI.Models;
using WebApiJumpStart.Models;

namespace WebApiJumpStart.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Weapon> Weapons { get; set; } = null!;
    }
}
