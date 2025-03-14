using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("Consulta")]
public class Consulta : _BaseEntity
{
	[Key]
	[Column("ID_Consulta")]
	public override long Id { get; set; }

	[Required]
	public DateTime Data_Consulta { get; set; }

	[Required]
	[ForeignKey("Paciente")]
	public long ID_Paciente { get; set; }

	[Required]
	[ForeignKey("Dentista")]
	public long ID_Dentista { get; set; }

	[Required]
	[StringLength(50)]
	public string Status { get; set; }

	// Navegação
	public Paciente Paciente { get; set; }
	public Dentista Dentista { get; set; }
	public ICollection<HistoricoConsulta> Historicos { get; set; }
}
