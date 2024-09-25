using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Doctor
{
    public string Name { get; set; }
    public string CRM { get; set; } // Registro profissional do médico
    public string Especialidade { get; set; } // Exemplo: "Ortodontia", "Cirurgia", "Periodontia"
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); //Relacionamento 1:N necessário para o Entity Framework
}
