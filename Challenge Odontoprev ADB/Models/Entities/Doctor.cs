using Challenge_Odontoprev_ADB.Models.Entities.Domain;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Doctor : _BaseEntity
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } // Nome do médico
    [Required]
    [RegularExpression(@"^\d{6}-\d{2}\/[A-Z]{2}$")]
    public string CRM { get; set; } // Registro profissional do médico "XXXXXX-XX/UF" (^\d{6}-\d{2}\/[A-Z]{2}$) 
    public virtual ICollection<Speciality>? Specialties { get; set; } = new List<Speciality>();

    [Required]
    //Relacionamento 1:N necessário para o Entity Framework (Um médico pode realizar várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); 
}
