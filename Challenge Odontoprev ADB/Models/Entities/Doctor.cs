using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Doctor
{
    public string Name { get; set; } // Nome do médico
    public string CRM { get; set; } // Registro profissional do médico
    public string Specialty { get; set; } // Especialidade médica

    //Relacionamento 1:N necessário para o Entity Framework (Um médico pode realizar várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); 
}
