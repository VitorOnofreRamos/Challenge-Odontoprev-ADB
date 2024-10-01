using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Appointment : _BaseEntity
{
    public string AppointmentType { get; set; } // tipos de consulta
    public string AppointmentReason { get; set; } // Motivo da consulta
    public Location Location { get; set; } // Local da consulta
    public AppointmentDate Date { get; set; } // Data da consulta
    public Patient Patient { get; set; } // Relação 1:1 com Patient (uma consulta tem um paciente)
    public Doctor Doctor { get; set; } // Relação 1:1 com Doctor (uma consulta tem um médico)
}
