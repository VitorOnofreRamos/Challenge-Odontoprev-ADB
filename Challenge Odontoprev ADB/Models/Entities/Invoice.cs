using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public class Invoice : _BaseEntity //Fatura/Recibo de Procedimento
{
    [Required]
    public decimal Amount { get; set; } // Valor da fatura
    [Required]
    public DateTime InvoiceDate { get; set; } // Data de emissão da fatura
    [Required]
    public string Status { get; set; } // Pago, Pendente, Cancelado
    [Required]
    public Appointment Appointment { get; set; } // Relacionamento 1:1 com Appointment (uma consulta gera uma fatura)
}
