using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Patient : _BaseEntity
{
    public string Name { get; set; } //Nome do Paciente
    public DateTime DateofBirth { get; set; } // Data de nascimento
    public string CPF { get; set; } // Identificação do paciente
    public string Genero { get; set; } // Gênero do paciente

    // Relacionamento com InsurancePlan (Paciente pode ter 1 plano de saúde)
    public InsurancePlan InsurancePlan { get; set; }

    // Relacionamento 1:N com Appointment (Um paciente pode ter várias consultas)s
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
