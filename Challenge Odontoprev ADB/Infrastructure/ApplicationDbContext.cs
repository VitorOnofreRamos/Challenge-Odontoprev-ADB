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
                Name = "Dr. João Silva",
                CRM = "123456-78/SP",
                Speciality = EnumDoctorSpeciality.GeneralDentistry,
                Phone = "(11) 1234-5678",
                CreatedAt = DateTime.Now
            }, 
            
            new Doctor
            {
                Id = 2,
                Name = "Dra. Maria Oliveira",
                CRM = "234567-89/MG",
                Speciality = EnumDoctorSpeciality.DentalResearch,
                Phone = "(11) 2345-6789",
                CreatedAt = DateTime.Now
            }, 
            
            new Doctor
            {
                Id = 3,
                Name = "Dr. Paulo Lima",
                CRM = "345678-91/SP",
                Speciality = EnumDoctorSpeciality.ForensicOdontology,
                Phone = "(11) 34567-8910",
                CreatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = 1,
                Name = "Lucas Pereira",
                CPF = "123.456.789-00",
                DateOfBirth = new DateTime(1987, 7, 22),
                Phone = "(11) 98765-4321",
                HealthCard = 12345,
                CreatedAt = DateTime.Now
            }, 
            
            new Patient
            {
                Id = 2,
                Name = "Miguel Alves",
                CPF = "234.555.779-20",
                DateOfBirth = new DateTime(2000, 12, 1),
                Phone = "(11) 9455-4771",
                HealthCard = 22365,
                CreatedAt = DateTime.Now
            }, 
            
            new Patient
            {
                Id = 3,
                Name = "Rafael Cardoso",
                CPF = "321.456.665-12",
                DateOfBirth = new DateTime(1998, 4, 22),
                Phone = "(11) 92775-5378",
                HealthCard = 87745,
                CreatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<Treatment>().HasData(
            new Treatment
            {
                Id = 1,
                ProcedureType = EnumProcedureType.Cleaning,
                ProcedureDescription = "Limpeza dental completa",
                Cost = 200,
                CreatedAt = DateTime.Now
            }, 
            
            new Treatment
            {
                Id = 2,
                ProcedureType = EnumProcedureType.Filling,
                ProcedureDescription = "Prenchimento dentário",
                Cost = 350,
                CreatedAt = DateTime.Now
            }, 
            
            new Treatment
            {
                Id = 3,
                ProcedureType = EnumProcedureType.Other,
                ProcedureDescription = null,
                Cost = 500,
                CreatedAt = DateTime.Now
            }
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

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
        modelBuilder.Entity<Appointment>()
            .HasOne(t => t.Treatment)
            .WithMany(a => a.Appointments)
            .HasForeignKey(t => t.TreatmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Chamada do método SeedData para adicionar dados iniciais
        SeedData(modelBuilder);
    }
}
