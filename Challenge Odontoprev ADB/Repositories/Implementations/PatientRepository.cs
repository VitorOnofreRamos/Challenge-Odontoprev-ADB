using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories.Implementations;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Repositories;

public class PatientRepository : _Repository<Patient>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Patient> GetPatientByNameAsync(string name)
    {
        return await _context.Patients
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}
