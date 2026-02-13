using EFUnderstandingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFUnderstandingApp.Contexts
{
    public class ClinicContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; } 
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;TrustServerCertificate=True;Integrated Security=True;Database=dbClinic13Feb26;");
        }
    }
}
