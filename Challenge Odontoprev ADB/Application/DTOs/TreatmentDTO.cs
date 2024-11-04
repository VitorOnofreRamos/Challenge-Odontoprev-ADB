using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class TreatmentDTO
{
    [Required]
    [EnumDataType(typeof(EnumProcedureType))]
    public EnumProcedureType ProcedureType { get; set; } // Tipo de procedimento

    public string? ProcedureDescription { get; set; }

    [Required]
    public ValueCost Cost { get; set; } // Custo do procedimento

    [Required]
    public int AppointmentId { get; set; }

}
