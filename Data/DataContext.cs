﻿using Microsoft.EntityFrameworkCore;
using WebApiJumpStart.Models;

namespace WebApiJumpStart.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; } = null!;

    }
}
