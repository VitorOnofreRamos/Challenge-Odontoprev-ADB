using System.ComponentModel.DataAnnotations;

namespace Challenge_Odontoprev_ADB.Views.ViewModels;

public class AppointmentViewModel
{
    public long ID_Consulta { get; set; }
	public DateTime Data_Consulta { get; set; }
	public string Status { get; set; }

	// Informações do Paciente
	public long ID_Paciente { get; set; }
	public string Nome_Paciente { get; set; }
	public DateTime Data_Nascimento { get; set; }
	public string CPF { get; set; }
	public string Endereco { get; set; }
	public string Telefone_Paciente { get; set; }
	public long Carteirinha { get; set; }

	// Informações do Dentista
	public long ID_Dentista { get; set; }
	public string Nome_Dentista { get; set; }
	public string CRO { get; set; }
	public string Especialidade { get; set; }
	public string Telefon_Dentista { get; set; }
}