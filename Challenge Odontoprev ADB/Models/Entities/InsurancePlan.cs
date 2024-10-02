using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class InsurancePlan : _BaseEntity //Plano Odontológico
{
    [Required]
    public string PlanName { get; set; } // Nome do plano de saúde
    [Required]
    public string PlanDetails { get; set; } // Detalhes do plano (cobertura, limites)

    [Required]
    // Relacionamento 1:N com Patient (um plano pode ter vários pacientes)
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
