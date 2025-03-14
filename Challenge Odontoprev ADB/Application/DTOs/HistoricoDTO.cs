namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class HistoricoDTO : _BaseDTO
{
	public long ID_Consulta { get; set; }
	public DateTime Data_Atendimento { get; set; }
	public string Motivo_Consulta { get; set; }
	public string Observacoes { get; set; }
}
