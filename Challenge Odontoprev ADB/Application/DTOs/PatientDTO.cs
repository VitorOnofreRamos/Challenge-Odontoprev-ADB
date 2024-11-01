using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class PatientDTO
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
    public string Address { get; set; } // Endereco do paciente

    [Required]
    [RegularExpression(@"^\\(\\d{2}\\)\\s\\d{4,5}-\\d{4}$")]
    [Column("Patient_Phone")]
    public string Phone { get; set; } // Telefone paciente

    [Required]
    [StringLength(5)]
    [Column("HealthCard")]
    public int HealthCard { get; set; } // Carterinha

    [Required]
    [ForeignKey(nameof(Appointment))]
    public int AppointmentId { get; set; }
}
