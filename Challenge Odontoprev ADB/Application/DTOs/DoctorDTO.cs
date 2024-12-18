﻿using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class DoctorDTO
{
    [Required]
    public string Name { get; set; } // Nome do médico

    [Required]
    [RegularExpression(@"^\d{6}-\d{2}\/[A-Z]{2}$")]
    public string CRM { get; set; } // Registro profissional do médico "XXXXXX-XX/UF" (^\d{6}-\d{2}\/[A-Z]{2}$) 

    [Required]
    [EnumDataType(typeof(EnumDoctorSpeciality))]
    public EnumDoctorSpeciality Speciality { get; set; }

    [Required]
    [RegularExpression(@"^\(\d{2}\)\s\d{4,5}-\d{4}$")]
    public string Phone { get; set; } // Telefone paciente

    [Required]
    [ForeignKey(nameof(Appointment))]
    public int AppointmentId { get; set; }
}
