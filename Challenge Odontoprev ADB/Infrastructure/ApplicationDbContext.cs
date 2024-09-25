using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Numerics;

namespace Challenge_Odontoprev_ADB.Infrastructure;

public class ApplicationDbContext : DbContext
{
    //Os DbSet's são propriedades que representam as tabelas do banco de dados
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Adicionando dados iniciais para Format
        modelBuilder.Entity<Patient>().HasData(
            new Patient {Id = 1, Name = "Paulin Bacana", Genero = "Masculino"}
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração para Price como Owned Type em Appointment

        //Configuração para Location como Owned Type em Appointment
    }
}
