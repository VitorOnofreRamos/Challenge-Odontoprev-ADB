using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("OdonPrev_Patient")]
public class Patient : _BaseEntity
{
    [Required]
    [Column("Patient_Name")]
    public string Name { get; set; } //Nome do Paciente

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Column("DateOfBirth")]
    public PassDate DateOfBirth { get; set; } // Data de nascimento

    [Required]
    [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")]
    [Column("CPF")]
    public string CPF { get; set; } // Identificação do paciente

    [Required]
    [Column("Address")]
    public LocationAddress Address { get; set; } // Endereco do paciente

    [Required]
    [RegularExpression(@"^\\(\\d{2}\\)\\s\\d{4,5}-\\d{4}$")]
    [Column("Patient_Phone")]
    public string Phone { get; set; } // Telefone paciente

    [Required]
    [StringLength(5)]
    [Column("HealthCard")]
    public int HealthCard { get; set; } // Carterinha

    //[Required]
    //[ForeignKey(nameof(Appointment))]
    //public int AppointmentId { get; set; }

    // Relacionamento 1:N com Appointment (Um paciente pode ter várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
