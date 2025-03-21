using Challenge_Odontoprev_ADB.Models.Entities;

namespace Challenge_Odontoprev_ADB.Application.Services;

public interface _IService
{
    Task<bool> IsConsultaAgendada(string status);
    Task<IEnumerable<Consulta>> FindConsultasInTimePeriod(DateTime dataInicio, DateTime dataFim);
    Task<IEnumerable<HistoricoConsulta>> FindHistoricoConsultasByPacienteId(long id);
}
