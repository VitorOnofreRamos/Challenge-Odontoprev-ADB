using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Views.ViewModels;

public class AppointmentViewModel
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string Address_Street { get; set; }
    public string Address_City { get; set; }
    public string Address_State { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? AppointmentReason { get; set; }

    // Informações do Paciente
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string CPF { get; set; }
    public string PatientPhone { get; set; }
    public int HealthCard { get; set; }

    // Informações do Médico
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public string CRM { get; set; }
    public string DoctorSpecialty { get; set; }
    public string DoctorPhone { get; set; }

    // Informações do Tratamento
    public int TreatmentId { get; set; }
    public string ProcedureType { get; set; }
    public string? TreatmentDescription { get; set; }
    public float Cost { get; set; }
}