using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Appointment : _BaseEntity
{
    //[Required]
    //public string AppointmentType { get; set; } // tipos de consulta (mudar para um enum)
    public string? AppointmentReason { get; set; } // Motivo da consulta
    public AppointmentLocation Location { get; set; } // Local da consulta
    public AppointmentDate Date { get; set; } // Data da consulta
    
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } // Relação 1:1 com Patient (uma consulta tem um paciente)
    
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; } // Relação 1:1 com Doctor (uma consulta tem um médico)

    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}
