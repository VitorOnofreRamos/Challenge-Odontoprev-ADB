using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Doctor : _BaseEntity
{
    public string Name { get; set; } // Nome do médico

    [RegularExpression(@"^\d{6}-\d{2}\/[A-Z]{2}$")]
    public string CRM { get; set; } // Registro profissional do médico "XXXXXX-XX/UF" (^\d{6}-\d{2}\/[A-Z]{2}$) 

    [EnumDataType(typeof(Speciality))]
    public virtual ICollection<Speciality>? Specialties { get; set; } = new List<Speciality>();

    //Relacionamento 1:N necessário para o Entity Framework (Um médico pode realizar várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); 
}
