﻿using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("OdonPrev_Appointment")]
public class Appointment : _BaseEntity
{
    [Required]
    [Column("AppointmentReason")]
    public string? AppointmentReason { get; set; } // Motivo da consulta

    [Required]
    [Column("Appointment_Location")]
    public LocationAddress Location { get; set; } // Local da consulta

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Column("Appointment_Date")]
    public FutureDate Date { get; set; } // Data da consulta
    
    [Required]
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } // Relação 1:1 com Patient (uma consulta tem um paciente)
    
    [Required]
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; } // Relação 1:1 com Doctor (uma consulta tem um médico)

    //[Required]
    //[ForeignKey(nameof(Treatment))]
    //public int TreatmentId { get; set; }

    [Required]
    [EnumDataType(typeof(AppointmentStatus))]
    [Column("Appointment_Status")]
    public AppointmentStatus Status { get; set; }

    public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}
