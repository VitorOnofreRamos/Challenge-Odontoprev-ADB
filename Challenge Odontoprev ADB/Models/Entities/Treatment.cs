﻿using Challenge_Odontoprev_ADB.Models.Entities.Enums;
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
    public float Cost { get; set; } // Custo do procedimento

    //Relacionamento 1:N necessário para o Entity Framework (Um médico pode realizar várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
