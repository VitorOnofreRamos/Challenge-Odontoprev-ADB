namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Procedure : _BaseEntity //Procedimentos odontológicos
{
    public string ProcedureName { get; set; } // Nome do procedimento (ex.: limpeza, canal)
    public decimal Cost { get; set; } // Custo do procedimento

    // Relacionamento N:N com Appointment (uma consulta pode ter vários procedimentos)
    //public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
