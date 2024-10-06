using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class AppointmentDTO
{
    [Required]
    public AppointmentLocation Location { get; set; } // Local da consulta
    [Required]
    public AppointmentDate Date { get; set; } // Data da consulta

    [Required]
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }

    [Required]
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
}
