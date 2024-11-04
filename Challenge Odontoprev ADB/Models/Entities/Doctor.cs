using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("OdonPrevDoctor")]
public class Doctor : _BaseEntity
{
    [Required]
    [Column("DoctorName")]
    public string Name { get; set; } // Nome do médico

    [Required]
    [RegularExpression(@"^\d{6}-\d{2}\/[A-Z]{2}$")]
    public string CRM { get; set; } // Registro profissional do médico "XXXXXX-XX/UF" (^\d{6}-\d{2}\/[A-Z]{2}$) 

    [Required]
    [EnumDataType(typeof(EnumDoctorSpeciality))]
    public EnumDoctorSpeciality Speciality { get; set; }

    [Required]
    [RegularExpression(@"^\(\d{2}\)\s\d{4,5}-\d{4}$")]
    [Column("DoctorPhone")]
    public string Phone { get; set; } // Telefone paciente

    //[Required]
    //[ForeignKey(nameof(Appointment))]
    //public int AppointmentId { get; set; }

    //Relacionamento 1:N necessário para o Entity Framework (Um médico pode realizar várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); 
}
