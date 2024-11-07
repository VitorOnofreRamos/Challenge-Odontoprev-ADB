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
        // Dados dos Doutores
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
            },
            new Doctor
            {
                Id = 4,
                Name = "Dra. Ana Costa",
                CRM = "456789-12/SP",
                Speciality = EnumDoctorSpeciality.Orthodontics,
                Phone = "(11) 3567-8910",
                CreatedAt = DateTime.Now
            },
            new Doctor
            {
                Id = 5,
                Name = "Dr. Gabriel Souza",
                CRM = "567890-23/MG",
                Speciality = EnumDoctorSpeciality.Periodontics,
                Phone = "(11) 4678-9012",
                CreatedAt = DateTime.Now
            },
            new Doctor
            {
                Id = 6,
                Name = "Dra. Carla Fernandes",
                CRM = "678901-34/RJ",
                Speciality = EnumDoctorSpeciality.PediatricDentistry,
                Phone = "(11) 5789-0123",
                CreatedAt = DateTime.Now
            },
            new Doctor
            {
                Id = 7,
                Name = "Dr. Ricardo Costa",
                CRM = "789012-45/SP",
                Speciality = EnumDoctorSpeciality.OralAndMaxillofacialSurgery,
                Phone = "(11) 6890-1234",
                CreatedAt = DateTime.Now
            },
            new Doctor
            {
                Id = 8,
                Name = "Dr. Felipe Martins",
                CRM = "890123-56/MG",
                Speciality = EnumDoctorSpeciality.Endodontics,
                Phone = "(11) 7901-2345",
                CreatedAt = DateTime.Now
            },
            new Doctor
            {
                Id = 9,
                Name = "Dra. Juliana Pereira",
                CRM = "901234-67/SP",
                Speciality = EnumDoctorSpeciality.Prosthodontics,
                Phone = "(11) 8912-3456",
                CreatedAt = DateTime.Now
            },
            new Doctor
            {
                Id = 10,
                Name = "Dr. Marcos Oliveira",
                CRM = "123456-78/RJ",
                Speciality = EnumDoctorSpeciality.DentalRestorativeDentistry,
                Phone = "(11) 9123-4567",
                CreatedAt = DateTime.Now
            }
        );

        // Dados dos Pacientes
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
            },
            new Patient
            {
                Id = 4,
                Name = "Beatriz Silva",
                CPF = "432.123.567-89",
                DateOfBirth = new DateTime(1995, 5, 15),
                Phone = "(11) 92928-5747",
                HealthCard = 33565,
                CreatedAt = DateTime.Now
            },
            new Patient
            {
                Id = 5,
                Name = "Daniel Costa",
                CPF = "543.876.987-10",
                DateOfBirth = new DateTime(1989, 8, 30),
                Phone = "(11) 93718-9223",
                HealthCard = 77345,
                CreatedAt = DateTime.Now
            },
            new Patient
            {
                Id = 6,
                Name = "Fernanda Gomes",
                CPF = "654.789.876-34",
                DateOfBirth = new DateTime(2001, 3, 18),
                Phone = "(11) 94576-5348",
                HealthCard = 12943,
                CreatedAt = DateTime.Now
            },
            new Patient
            {
                Id = 7,
                Name = "João Silva",
                CPF = "765.432.098-76",
                DateOfBirth = new DateTime(1990, 10, 12),
                Phone = "(11) 91234-7645",
                HealthCard = 34985,
                CreatedAt = DateTime.Now
            },
            new Patient
            {
                Id = 8,
                Name = "Carla Oliveira",
                CPF = "876.543.210-21",
                DateOfBirth = new DateTime(1992, 9, 5),
                Phone = "(11) 92347-8823",
                HealthCard = 22345,
                CreatedAt = DateTime.Now
            },
            new Patient
            {
                Id = 9,
                Name = "Paulo Santos",
                CPF = "987.654.321-32",
                DateOfBirth = new DateTime(1985, 11, 14),
                Phone = "(11) 93452-7123",
                HealthCard = 66782,
                CreatedAt = DateTime.Now
            },
            new Patient
            {
                Id = 10,
                Name = "Larissa Pereira",
                CPF = "109.876.543-21",
                DateOfBirth = new DateTime(1997, 4, 28),
                Phone = "(11) 93467-5432",
                HealthCard = 99877,
                CreatedAt = DateTime.Now
            }
        );

        // Dados dos Tratamentos
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
            },
            new Treatment
            {
                Id = 4,
                ProcedureType = EnumProcedureType.Extraction,
                ProcedureDescription = "Extração de dente",
                Cost = 250,
                CreatedAt = DateTime.Now
            },
            new Treatment
            {
                Id = 5,
                ProcedureType = EnumProcedureType.RootCanal,
                ProcedureDescription = "Canal radicular",
                Cost = 450,
                CreatedAt = DateTime.Now
            },
            new Treatment
            {
                Id = 6,
                ProcedureType = EnumProcedureType.Crown,
                ProcedureDescription = "Coroa dentária",
                Cost = 700,
                CreatedAt = DateTime.Now
            },
            new Treatment
            {
                Id = 7,
                ProcedureType = EnumProcedureType.Bridge,
                ProcedureDescription = "Prótese dentária",
                Cost = 800,
                CreatedAt = DateTime.Now
            },
            new Treatment
            {
                Id = 8,
                ProcedureType = EnumProcedureType.Implant,
                ProcedureDescription = "Implante dentário",
                Cost = 1200,
                CreatedAt = DateTime.Now
            },
            new Treatment
            {
                Id = 9,
                ProcedureType = EnumProcedureType.OrthodonticTreatment,
                ProcedureDescription = "Tratamento ortodôntico",
                Cost = 1500,
                CreatedAt = DateTime.Now
            },
            new Treatment
            {
                Id = 10,
                ProcedureType = EnumProcedureType.PeriodontalTreatment,
                ProcedureDescription = "Tratamento periodontal",
                Cost = 400,
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
