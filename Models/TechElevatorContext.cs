using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Models
{
    public class TechElevatorContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=techelevator.db");
        }
    }
}