using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Appointment : _BaseEntity
{
    [Required]
    public string AppointmentType { get; set; } // tipos de consulta (mudar para um enum)
    [Required]
    public string AppointmentReason { get; set; } // Motivo da consulta
    [Required]
    public Location Location { get; set; } // Local da consulta
    [Required]
    public AppointmentDate Date { get; set; } // Data da consulta
    [Required]
    public Patient Patient { get; set; } // Relação 1:1 com Patient (uma consulta tem um paciente)
    [Required]
    [ForeignKey(nameof(PatientId))]
    public int PatientId { get; set; }
    [Required]
    public Doctor Doctor { get; set; } // Relação 1:1 com Doctor (uma consulta tem um médico)
    [Required]
    [ForeignKey(nameof(DoctorId))]
    public int DoctorId { get; set; }
}
