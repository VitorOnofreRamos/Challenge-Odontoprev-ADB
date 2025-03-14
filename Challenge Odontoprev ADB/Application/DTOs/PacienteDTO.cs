namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class PacienteDTO : _BaseDTO
{
	public string Nome { get; set; }
	public DateTime Data_Nascimento { get; set; }
	public string CPF { get; set; }
	public string Endereco { get; set; }
	public string Telefone { get; set; }
	public long Carteirinha { get; set; }
}