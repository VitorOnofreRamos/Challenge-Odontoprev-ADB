using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class PatientDTO
{
    [Required]
    public string Name { get; set; } //Nome do Paciente

    [Required]
    //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; } // Data de nascimento

    [Required]
    [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")]
    public string CPF { get; set; } // Identificação do paciente

    [Required]
    [RegularExpression(@"^\\(\\d{2}\\)\\s\\d{4,5}-\\d{4}$")]
    public string Phone { get; set; } // Telefone paciente

    [Required]
    [Range(10000, 99999)]
    public int HealthCard { get; set; } // Carterinha

    [Required]
    public int AppointmentId { get; set; }
}
