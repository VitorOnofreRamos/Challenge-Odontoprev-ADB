namespace Challenge_Odontoprev_ADB.Application.DTOs;

public class HistoricoConsultaCreateDTO
{
    public long ID_Consulta { get; set; }
    public DateTime Data_Atendimento { get; set; }
    public string Motivo_Consulta { get; set; }
    public string Observacoes { get; set; }
}

public class HistoricoConsultaReadDTO
{
    public long ID_HISTORICO { get; set; }
    public long ID_Consulta { get; set; }
    public DateTime Data_Atendimento { get; set; }
    public string Motivo_Consulta { get; set; }
    public string Observacoes { get; set; }
}
