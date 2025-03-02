using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleToDoManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleToDoManager.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TodoManager;Username=postgres;Password=Rp_9i7g7");
        }
    }
}
