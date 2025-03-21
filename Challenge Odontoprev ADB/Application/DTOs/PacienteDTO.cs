namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class PacienteCreateDTO
{
    public string Nome { get; set; }
    public DateTime Data_Nascimento { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public long Carteirinha { get; set; }
}

public class PacienteReadDTO
{
    public long ID_Paciente { get; set; }
    public string Nome { get; set; }
    public DateTime Data_Nascimento { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public long Carteirinha { get; set; }
}

