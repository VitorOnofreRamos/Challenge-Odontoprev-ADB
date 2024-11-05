using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("OdonPrev_Appointment")]
public class Appointment : _BaseEntity
{
    public string? AppointmentReason { get; set; } // Motivo da consulta

    // Adicione as propriedades do ValueObject aqui
    [Required]
    public string Address_Street { get; set; }
    [Required]
    public string Address_City { get; set; }
    [Required]
    public string Address_State { get; set; }

    [Required]
    //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "TIMESTAMP")]
    public DateTime AppointmentDate { get; set; } // Data da consulta
    
    [Required]
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } // Relação 1:1 com Patient (uma consulta tem um paciente)
    
    [Required]
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; } // Relação 1:1 com Doctor (uma consulta tem um médico)

    [Required]
    [ForeignKey(nameof(Treatment))]
    public int TreatmentId { get; set; }
    public virtual Treatment Treatment { get; set; }

    [Required]
    [EnumDataType(typeof(EnumAppointmentStatus))]
    public EnumAppointmentStatus Status { get; set; }
}
