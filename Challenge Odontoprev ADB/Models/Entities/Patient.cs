using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Patient : _BaseEntity
{
    public string Name { get; set; } //Nome do Paciente

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DateofBirth { get; set; } // Data de nascimento
    
    [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}")]
    public string CPF { get; set; } // Identificação do paciente
    
    [EnumDataType(typeof(Gender))]
    public Gender? Gender { get; set; } // Gênero do paciente

    // Relacionamento 1:N com Appointment (Um paciente pode ter várias consultas)
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
