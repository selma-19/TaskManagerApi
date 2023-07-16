using Microsoft.EntityFrameworkCore;

namespace TaskManager.DbContexts
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KPFA88B\\\\MSSQLSERVER01;Database=CityInfoDB;Integrated ;Security=true;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasKey(t => t.Id);

            // ... any additional configuration for your entities

            base.OnModelCreating(modelBuilder);
        }
    }
}
