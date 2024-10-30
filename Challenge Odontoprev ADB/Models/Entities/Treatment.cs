using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Treatment : _BaseEntity //Procedimentos odontológicos
{
    [Required]
    [EnumDataType(typeof(ProcedureType))]
    public ProcedureType ProcedureType { get; set; } // Tipo de procedimento
    
    public string? ProcedureDescription { get; set; }

    [Required]
    public Cost Cost { get; set; } // Custo do procedimento

    [Required]
    [ForeignKey(nameof(Appointment))]
    public int AppointmentId { get; set; }
    public virtual Appointment Appointment { get; set; }
}
