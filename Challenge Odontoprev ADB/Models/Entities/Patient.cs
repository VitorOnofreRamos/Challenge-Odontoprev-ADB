using Challenge_Odontoprev_ADB.Models.Entities.Domain;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Patient : _BaseEntity
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } //Nome do Paciente
    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DateofBirth { get; set; } // Data de nascimento
    [Required]
    [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")]
    public string CPF { get; set; } // Identificação do paciente
    [EnumDataType(typeof(Gender))]
    public Gender? Gender { get; set; } // Gênero do paciente

    //[Required]
    //// Relacionamento com InsurancePlan (Paciente só pode usar um plano de sáude, por consulta)
    //public virtual ICollection<InsurancePlan> InsurancePlan { get; set; } = new List<InsurancePlan>();

    [Required]
    // Relacionamento 1:N com Appointment (Um paciente pode ter várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
