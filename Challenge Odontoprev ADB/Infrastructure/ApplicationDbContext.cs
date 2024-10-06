using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Numerics;

namespace Challenge_Odontoprev_ADB.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Treatment> Treatments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Doctor>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<Appointment>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Treatment>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<Appointment>()
            .HasOne(c => c.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(c => c.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
            .HasOne(c => c.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(c => c.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Treatment>()
            .HasOne(t => t.Appointment)
            .WithMany(c => c.Treatments)
            .HasForeignKey(t => t.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    //private void SeedData(ModelBuilder modelBuilder)
    //{
    //    // Adicionando dados iniciais para Format
    //    modelBuilder.Entity<Patient>().HasData(
    //        new Patient {Id = 1, Name = "Paulin Bacana", Genero = "Masculino"}
    //    );
    //}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Configuração para Price como Owned Type em Appointment

    //    //Configuração para Location como Owned Type em Appointment
    //}
}
