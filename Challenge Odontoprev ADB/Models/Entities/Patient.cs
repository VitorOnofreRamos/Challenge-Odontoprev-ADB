using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Patient : _BaseEntity
{
    public string Name { get; set; }
    public DateTime DateofBirth { get; set; }
    public string CPF { get; set; } // Identificação do paciente
    public string Genero { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); //Relacionamento 1:N necessário para o Entity Framework
    //public PlanoSaude PlanoSaude { get; set; } // Nome do plano odontológico
    //public HistoricoMedico HistoricoMedico { get; set; } // Histórico de condições médicas relevantes
    //public PerfilDeRisco PerfilDeRisco { get; set; } // Score inicial baseado em dados de consultas anteriores (0 a 1)
}
