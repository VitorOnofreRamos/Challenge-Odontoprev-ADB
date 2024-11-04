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
            new Doctor
            {
                Id = 1,
                Name = "Dr. Teste",
                CRM = "123456-78/SP",
                Speciality = EnumDoctorSpeciality.GeneralDentistry,
                Phone = "(11) 1234-5678",
                CreatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = 1,
                Name = "Paciente Teste",
                CPF = "123.456.789-00",
                DateOfBirth = new DateTime(1987, 7, 22),
                Phone = "(11) 98765-4321",
                HealthCard = 12345,
                CreatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                Id = 1,
                AppointmentReason = "Consulta inicial",
                Address_Street = "Rua C, 789",
                Address_City = "São Paulo",
                Address_State = "SP",
                AppointmentDate = new DateTime(2025, 8, 10),
                PatientId = 1,
                DoctorId = 1,
                Status = EnumAppointmentStatus.AGENDADA,
                CreatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<Treatment>().HasData(
            new Treatment
            {
                Id = 1,
                ProcedureType = EnumProcedureType.Cleaning,
                ProcedureDescription = "Limpeza dental completa",
                Cost = 200, // Valor em Reais
                AppointmentId = 1,
                CreatedAt = DateTime.Now
            }
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração dos ValueObjects para Cost, LocationAddress e FutureDate

        // Configuração para Cost como Owned Type em Treatment
        //modelBuilder.Entity<Treatment>().OwnsOne(t => t.Cost, cost =>
        //{
        //    cost.Property(c => c.Amount).HasColumnName("Cost").HasColumnType("decimal(18,2)");
        //});

        // Configuração para LocationAddress como Owned Type em Appointment
        //modelBuilder.Entity<Appointment>().OwnsOne(a => a.Address, loc =>
        //{
        //    loc.Property(l => l.Street).HasColumnName("Street").HasMaxLength(100);
        //    loc.Property(l => l.City).HasColumnName("City").HasMaxLength(50);
        //    loc.Property(l => l.State).HasColumnName("State").HasMaxLength(50);
        //});

        // Configuração de relacionamento entre Appointment e Patient
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração de relacionamento entre Appointment e Doctor
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração de relacionamento entre Treatment e Appointment
        modelBuilder.Entity<Treatment>()
            .HasOne(t => t.Appointment)
            .WithMany(a => a.Treatments)
            .HasForeignKey(t => t.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Chamada do método SeedData para adicionar dados iniciais
        SeedData(modelBuilder);
    }
}
