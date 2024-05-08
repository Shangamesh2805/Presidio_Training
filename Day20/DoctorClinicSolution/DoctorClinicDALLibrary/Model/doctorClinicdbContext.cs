using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoctorClinicDALLibrary.Model
{
    public partial class doctorClinicdbContext : DbContext
    {
        public doctorClinicdbContext()
        {
        }

        public doctorClinicdbContext(DbContextOptions<doctorClinicdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=353CBX3\\DEMOINSTANCE;Initial Catalog=doctorClinicdb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Appointment_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DocId).HasColumnName("Doc_ID");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DocId)
                    .HasConstraintName("FK__Appointme__Doc_I__4D94879B");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__Patie__4E88ABD4");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PK__Doctors__464738211FE8C0E6");

                entity.Property(e => e.DocId)
                    .ValueGeneratedNever()
                    .HasColumnName("Doc_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("Patient_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
