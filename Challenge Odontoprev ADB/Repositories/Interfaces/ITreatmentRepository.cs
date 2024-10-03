using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Models.Entities.Domain;

namespace Challenge_Odontoprev_ADB.Repositories.Interfaces;

public interface ITreatmentRepository : _IRepository<Treatment>
{
    Task<Treatment> GetTreatmentByProcedureTypeAsync(ProcedureType procedure);
}
