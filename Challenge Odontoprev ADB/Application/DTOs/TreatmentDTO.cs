using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class TreatmentDTO
{
    [Required]
    [EnumDataType(typeof(ProcedureType))]
    public ProcedureType ProcedureType { get; set; } // Tipo de procedimento

    public string? ProcedureDescription { get; set; }

    [Required]
    public Cost Cost { get; set; } // Custo do procedimento

    public virtual Appointment Appointment { get; set; }
}
