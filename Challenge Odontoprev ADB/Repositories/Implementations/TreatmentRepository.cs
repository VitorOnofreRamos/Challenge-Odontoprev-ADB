using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Models.Entities.Enums;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Repositories.Implementations;

public class TreatmentRepository : _Repository<Treatment>, ITreatmentRepository
{
    public TreatmentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Treatment> GetTreatmentByProcedureTypeAsync(EnumProcedureType procedure)
    {
        return await _context.Treatments
            .FirstOrDefaultAsync(c => c.ProcedureType == procedure);
    }
}
