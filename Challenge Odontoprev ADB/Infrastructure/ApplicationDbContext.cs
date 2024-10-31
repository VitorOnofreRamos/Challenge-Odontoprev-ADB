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
        //Configuração para Patient
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("OdonPrev_Patient");

            entity.HasKey(e => e.Id); // Chave primária

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasColumnName("Patient_Name");

            entity.Property(e => e.DateOfBirth)
                  .IsRequired()
                  .HasColumnName("DateOfBirth");

            entity.Property(e => e.CPF)
                  .IsRequired()
                  .HasColumnName("CPF");

            entity.Property(e => e.Address)
                  .IsRequired()
                  .HasColumnName("Address");

            entity.Property(e => e.Phone)
                  .IsRequired()
                  .HasColumnName("Patient_Phone");

            entity.Property(e => e.HealthCard)
                  .IsRequired()
                  .HasColumnName("HealthCard");
        });

        // Configuração para Doctor
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("OdonPrev_Doctor");

            entity.HasKey(e => e.Id); // Chave primária

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasColumnName("Doctor_Name");

            entity.Property(e => e.CRM)
                  .IsRequired()
                  .HasColumnName("CRM");

            entity.Property(e => e.Speciality)
                  .IsRequired()
                  .HasColumnName("Speciality");

            entity.Property(e => e.Phone)
                  .IsRequired()
                  .HasColumnName("Doctor_Phone");
        });

        // Configuração para Appointment
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("OdonPrev_Appointment");

            entity.HasKey(e => e.Id); // Chave primária

            entity.Property(e => e.AppointmentReason)
                  .HasColumnName("AppointmentReason");

            entity.Property(e => e.Location)
                  .IsRequired()
                  .HasColumnName("Appointment_Location");

            entity.Property(e => e.Date)
                  .IsRequired()
                  .HasColumnName("Appointment_Date");

            entity.Property(e => e.Status)
                  .IsRequired()
                  .HasColumnName("Appointment_Status");

            // Configurar relacionamentos
            entity.HasOne(e => e.Patient)
                  .WithMany(e => e.Appointments)
                  .HasForeignKey(e => e.PatientId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Doctor)
                  .WithMany(e => e.Appointments)
                  .HasForeignKey(e => e.DoctorId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Treatments)
                  .WithOne(e => e.Appointment)
                  .HasForeignKey(e => e.AppointmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuração para Treatment
        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.ToTable("OdonPrev_Treatment");

            entity.HasKey(e => e.Id); // Chave primária

            entity.Property(e => e.ProcedureType)
                  .IsRequired();

            entity.Property(e => e.ProcedureDescription)
                  .HasColumnName("ProcedureDescription");

            entity.Property(e => e.Cost)
                  .IsRequired();

            // Relacionamento já definido em Appointment
            entity.HasOne(e => e.Appointment)
                  .WithMany(e => e.Treatments)
                  .HasForeignKey(e => e.AppointmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        //modelBuilder.Entity<Patient>()
        //    .HasKey(p => p.Id);

        //modelBuilder.Entity<Doctor>()
        //    .HasKey(d => d.Id);

        //modelBuilder.Entity<Appointment>()
        //    .HasKey(c => c.Id);

        //modelBuilder.Entity<Treatment>()
        //    .HasKey(t => t.Id);

        //modelBuilder.Entity<Appointment>()
        //    .HasOne(c => c.Patient)
        //    .WithMany(p => p.Appointments)
        //    .HasForeignKey(c => c.PatientId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Appointment>()
        //    .HasOne(c => c.Doctor)
        //    .WithMany(d => d.Appointments)
        //    .HasForeignKey(c => c.DoctorId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Treatment>()
        //    .HasOne(t => t.Appointment)
        //    .WithMany(c => c.Treatments)
        //    .HasForeignKey(t => t.AppointmentId)
        //    .OnDelete(DeleteBehavior.Cascade);
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
