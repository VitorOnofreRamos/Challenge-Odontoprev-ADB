using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class AppointmentDTO
{
    public string? AppointmentReason { get; set; } // Motivo da consulta

    [Required]
    public string Address_Street { get; set; } // Local da consulta
    [Required]
    public string Address_City { get; set; }
    [Required]
    public string Address_State { get; set; }

    [Required]
    //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime AppointmentDate { get; set; } // Data da consulta

    [Required]
    public int PatientId { get; set; }

    [Required]
    public int DoctorId { get; set; }

    [Required]
    public int TreatmentId { get; set; }

    [Required]
    [EnumDataType(typeof(EnumAppointmentStatus))]
    public EnumAppointmentStatus Status { get; set; }
}
