using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Appointment : _BaseEntity
{
    public string AppointmentType { get; set; }
    public string AppointmentReason { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public Price Price { get; set; }
    public Location Location { get; set; }
    public AppointmentDate Date { get; set; }
}
