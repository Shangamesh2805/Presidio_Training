
using DoctorClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicAPI.Context
{
    public class DoctorClinicContext : DbContext
    {
        public DoctorClinicContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Arun", Age = 32, Gender = "Male", Specialization = "Dentist", Experience = 5.5f },
                new Doctor() { Id = 102, Name = "Karthik", Age = 51, Gender = "Male", Specialization = "Surgeon", Experience = 2.0f },
                new Doctor() { Id = 103, Name = "Raj", Age = 65, Gender = "Male", Specialization = "Dentist", Experience = 7.5f },
                new Doctor() { Id = 104, Name = "Lakshmi", Age = 73, Gender = "Female", Specialization = "Surgeon", Experience = 23.0f },
                new Doctor() { Id = 105, Name = "Vijay", Age = 42, Gender = "Male", Specialization = "Dentist", Experience = 1.5f },
                new Doctor() { Id = 106, Name = "Priya", Age = 76, Gender = "Female", Specialization = "Dermatologist", Experience = 73.0f }

                );
        }
    }
}