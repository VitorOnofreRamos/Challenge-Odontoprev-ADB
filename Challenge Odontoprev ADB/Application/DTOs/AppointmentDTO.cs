using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Challenge_Odontoprev_ADB.Application.DTOs.ValidationAttributes;

namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class AppointmentDTO
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "O Status da consulta é obrigatório.")]
    public EnumAppointmentStatus Status { get; set; }
    [Required(ErrorMessage ="O Endereço da consulta é obrigatório")]
    [StringLength(100)]
    public string Address_Street { get; set; }
    [Required(ErrorMessage = "A cidade da consulta é obrigatória")]
    [StringLength(50)]
    public string Address_City { get; set; }
    [Required(ErrorMessage = "O estado da consulta é obrigatório")]
    [StringLength(50)]
    public string Address_State { get; set; }
	[Required(ErrorMessage = "A data da consulta é obrigatória.")]
	[FutureDate(ErrorMessage = "A data da consulta deve ser no futuro.")]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; }
    [Required(ErrorMessage = "O Paciente é obrigátorio")]
    public int PatientId{ get; set; }
    [Required(ErrorMessage = "O Doutor é obrigátorio")]
    public int DoctorId { get; set; }
    [Required(ErrorMessage = "O Tratamento é obrigátorio")]
    public int TreatmentId { get; set; }
    public string? AppointmentReason { get; set; }
}
