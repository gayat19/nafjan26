
using ClinicManagementModelsLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementDALLibrary.Contexts
{
    public class ClinicContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;TrustServerCertificate=True;Integrated Security=True;Database=dbClinic13Feb26;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.AppointmnetNumber)
                .HasName("PK_Appointments_AppointmnetNumber");

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Speciality)
                .WithMany(s=>s.Doctors)
                .HasForeignKey(d => d.SpecialityId)
                .HasConstraintName("FK_Doctors_Specialities_SpecialityId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .HasConstraintName("FK_Appointments_Doctors_DoctorId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
              .HasOne(a => a.Patient)
              .WithMany(p=>p.Appointments)
              .HasForeignKey(a => a.PatientId)
              .HasConstraintName("FK_Appointments_Patients_PatientId")
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Speciality>()
                .HasData(
                    new Speciality { Id = 1, Name = "Cardiology" },
                    new Speciality { Id = 2, Name = "Dermatology" },
                    new Speciality { Id = 3, Name = "Neurology" }
                );
            modelBuilder.Entity<Patient>()
                .HasData(
                    new Patient { Id = 1, Name = "John Doe", Phone="9876543210" },
                    new Patient { Id = 2, Name = "Jane Smith", Phone = "3210987654" },
                    new Patient { Id = 3, Name = "Emily Johnson", Phone = "8765432109" }
                );
            modelBuilder.Entity<Doctor>()
                .HasData(
                new Doctor { Id = 1,Name = "Dr. Smith", SpecialityId = 1 },
                new Doctor { Id = 2,Name = "Dr. Johnson", SpecialityId = 2 },
                new Doctor { Id = 3,Name = "Dr. Williams", SpecialityId = 1 }
                );

        }
    }
}
