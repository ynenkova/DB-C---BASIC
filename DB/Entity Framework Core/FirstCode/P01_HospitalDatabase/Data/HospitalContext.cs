namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }
        public HospitalContext(DbContextOptions options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-EJ1MT1A4;Database=HospitalDatabase;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(entity => {
                entity.HasOne(pm => pm.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(pm => pm.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasKey(k => new { k.MedicamentId, k.PatientId });
            });

            modelBuilder.Entity<Patient>(patient =>
            {
                patient
                    .Property(p => p.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                patient
                    .Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                patient
                    .Property(p => p.Address)
                    .HasMaxLength(250)
                    .IsUnicode();

                patient
                    .Property(p => p.Email)
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Visitation>(visitation =>
            {
                visitation
                    .Property(v => v.Comments)
                    .HasMaxLength(250)
                    .IsUnicode();

                visitation
                    .HasOne(v => v.Patient)
                    .WithMany(v => v.Visitations)
                    .HasForeignKey(v => v.PatientId);


            });

            modelBuilder.Entity<Diagnose>(diagnose =>
            {
                diagnose
                    .Property(d => d.Name)
                    .HasMaxLength(50)
                    .IsUnicode();

                diagnose
                    .Property(d => d.Comments)
                    .HasMaxLength(250)
                    .IsUnicode();
            });

            modelBuilder.Entity<Medicament>()
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode();
            modelBuilder.Entity<Doctor>(doctor =>
            {
                doctor.HasKey(doctor => doctor.DoctorId);

                doctor.Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode();

                doctor.Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsUnicode();

                doctor.HasMany(d => d.Visitations)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId);
            });
                
        }
    }
}

