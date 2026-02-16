using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Contexts
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, Name = "Ramu", Experience = 2 },
                new Doctor() { Id = 2, Name = "Somu", Experience = 3 }
            );
        }
    }
}
