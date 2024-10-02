using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Doctor
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } // Nome do médico
    [Required]
    public string CRM { get; set; } // Registro profissional do médico
    [Required]
    public string Specialty { get; set; } // Especialidade médica (mudar para um enum)

    [Required]
    //Relacionamento 1:N necessário para o Entity Framework (Um médico pode realizar várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); 
}
