using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class AppointmentDTO
{
    public int? Id { get; set; }
    [Required]
    public EnumAppointmentStatus Status { get; set; }
    [Required]
    [StringLength(100)]
    public string Address_Street { get; set; }
    [Required]
    [StringLength(50)]
    public string Address_City { get; set; }
    [Required]
    [StringLength(50)]
    public string Address_State { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; }
    [Required]
    public int PatientId{ get; set; }
    [Required]
    public int DoctorId { get; set; }
    [Required]
    public int TreatmentId { get; set; }
    public string? AppointmentReason { get; set; }
}
