using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("OdonPrev_Treatment")]
public class Treatment : _BaseEntity //Procedimentos odontológicos
{
    [Required]
    [EnumDataType(typeof(EnumProcedureType))]
    public EnumProcedureType ProcedureType { get; set; } // Tipo de procedimento

    public string? ProcedureDescription { get; set; }

    [Required]
    public ValueCost Cost { get; set; } // Custo do procedimento

    [Required]
    [ForeignKey(nameof(Appointment))]
    public int AppointmentId { get; set; }

    public virtual Appointment Appointment { get; set; }
}
