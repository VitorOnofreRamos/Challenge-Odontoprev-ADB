using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using System.Numerics;
using Challenge_Odontoprev_ADB.Models;
using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.Globalization;

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

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Adicionando dados iniciais para Format
        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Name = "Paulin Bacana",
                DateofBirth = DateTime.ParseExact("15/05/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                CPF = "123.456.789-00",
                Gender = "Masculino"
            },
            new Patient
            {
                Name = "Paulin Jr.",
                DateofBirth = DateTime.ParseExact("15/05/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                CPF = "234.567.891-00",
                Gender = "Feminino"
            },
            new Patient
            {
                Name = "Paulin Desbacana",
                DateofBirth = DateTime.ParseExact("15/05/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                CPF = "345.678.912-00",
                Gender = "Masculino"
            },
            new Patient
            {
                Name = "Bacana Paulin",
                DateofBirth = DateTime.ParseExact("15/05/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                CPF = "456.789.123-00",
                Gender = "Masculino"
            }
        );
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Configuração para Price como Owned Type em Appointment

    //    //Configuração para Location como Owned Type em Appointment
    //}
}
