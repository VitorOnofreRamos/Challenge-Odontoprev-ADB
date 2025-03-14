using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("Dentista")]
public class Dentista : _BaseEntity
{
	[Key]
	[Column("ID_Dentista")]
	public override long Id { get; set; }

	[Required]
	[StringLength(100)]
	public string Nome { get; set; }

	[Required]
	[StringLength(20)]
	public string CRO { get; set; }

	[Required]
	[StringLength(50)]
	public string Especialidade { get; set; }

	[Required]
	[StringLength(20)]
	public string Telefone { get; set; }

	// Navegação (opcional)
	public ICollection<Consulta> Consultas { get; set; }
}
