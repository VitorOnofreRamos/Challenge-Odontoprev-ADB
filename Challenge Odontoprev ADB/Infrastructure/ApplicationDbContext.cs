using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Models.Entities.Enums;
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

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { Id = 1, Name = "Dr. João", CRM = "123456-78/SP", Speciality = DoctorSpeciality.GeneralDentistry, Phone = "(11) 1234-5678" }
        );

        //modelBuilder.Entity<Patient>().HasData(
        //    new Patient { Id = 1, Name = "Maria Silva", CPF = "123.456.789-00", Address = "Rua A, 123", DateOfBirth = "10/5/1990", Phone = "(11) 98765-4321", HealthCard = 12345 }
        //);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações específicas de propriedades e relacionamentos

        // Configuração para campos de endereço do paciente (se necessário)
        modelBuilder.Entity<Patient>().OwnsOne(p => p.Address, address =>
        {
            address.Property(a => a.Street).HasColumnName("Street").HasMaxLength(150);
            address.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
            address.Property(a => a.State).HasColumnName("State").HasMaxLength(50);
        });

        // Configuração da relação entre Appointment e Patient
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração da relação entre Appointment e Doctor
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração da relação entre Appointment e Treatment
        modelBuilder.Entity<Appointment>()
            .HasMany(a => a.Treatments)
            .WithOne(t => t.Appointment)
            .HasForeignKey(t => t.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuração da relação entre Treatment e Appointment (1:N)
        modelBuilder.Entity<Treatment>()
            .HasOne(t => t.Appointment)
            .WithMany(a => a.Treatments)
            .HasForeignKey(t => t.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração adicional para o custo como Owned Type em Treatment
        modelBuilder.Entity<Treatment>().OwnsOne(t => t.Cost, cost =>
        {
            cost.Property(c => c.Amount).HasColumnName("Cost").HasColumnType("decimal(18,2)");
        });
    }
}
