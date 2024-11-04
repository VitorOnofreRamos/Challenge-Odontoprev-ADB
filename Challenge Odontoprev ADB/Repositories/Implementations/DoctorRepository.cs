using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories.Implementations;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Repositories.Implementations;

public class DoctorRepository : _Repository<Doctor>, IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Doctor> GetDoctorByCRMAsync(string crm)
    {
        return await _context.Doctors
            .FirstOrDefaultAsync(c => c.CRM == crm);
    }
}
