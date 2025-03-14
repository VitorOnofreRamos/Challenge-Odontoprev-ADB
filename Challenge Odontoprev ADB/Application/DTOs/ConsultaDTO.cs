namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class ConsultaDTO : _BaseDTO
{
	public DateTime Data_Consulta { get; set; }
	public long ID_Paciente { get; set; }
	public long ID_Dentista { get; set; }
	public string Status { get; set; }
}
