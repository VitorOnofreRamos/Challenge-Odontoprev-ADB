using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("OdonPrev_Patient")]
public class Patient : _BaseEntity
{
    [Required]
    [Column("PatientName")]
    public string Name { get; set; } //Nome do Paciente

    [Required]
    //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "TIMESTAMP")]
    public DateTime DateOfBirth { get; set; } // Data de nascimento

    [Required]
    [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")]
    public string CPF { get; set; } // Identificação do paciente

    [Required]
    [RegularExpression(@"^\\(\\d{2}\\)\\s\\d{4,5}-\\d{4}$")]
    [Column("PatientPhone")]
    public string Phone { get; set; } // Telefone paciente

    [Required]
    [Range(10000, 99999)]
    public int HealthCard { get; set; } // Carterinha

    // Relacionamento 1:N com Appointment (Um paciente pode ter várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
