using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("Paciente")]
public class Paciente : _BaseEntity
{
    [Key]
    [Column("ID_Paciente")]
    public override long Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Nome { get; set; }

    [Required]
    public DateTime Data_Nascimento { get; set; }

    [Required]
    [StringLength(14)]
    public string CPF { get; set; }

    [Required]
    [StringLength(200)]
    public string Endereco { get; set; }

    [Required]
    [StringLength(20)]
    public string Telefone { get; set; }

    [Required]
    public long Carteirinha { get; set; }

    public ICollection<Consulta> Consultas { get; set; }
}
