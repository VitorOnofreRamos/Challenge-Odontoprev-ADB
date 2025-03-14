using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_ADB.Models.Entities;

[Table("Historico_Consulta")]
public class HistoricoConsulta : _BaseEntity
{
	[Key]
	[Column("ID_Historico")]
	public override long Id { get; set; }

	[Required]
	[ForeignKey("Consulta")]
	public long ID_Consulta { get; set; }

	[Required]
	public DateTime Data_Atendimento { get; set; }

	[Required]
	[StringLength(300)]
	public string Motivo_Consulta { get; set; }

	[StringLength(300)]
	public string Observacoes { get; set; }

	// Navegação
	public Consulta Consulta { get; set; }
}
