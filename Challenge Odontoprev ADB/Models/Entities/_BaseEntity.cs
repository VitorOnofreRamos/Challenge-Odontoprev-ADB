using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Models.Entities;

public abstract class _BaseEntity
{
    [Key] // Marca como chave primária
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que o ID será gerado automaticamente
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
