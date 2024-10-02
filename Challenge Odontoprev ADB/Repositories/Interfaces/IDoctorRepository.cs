using Challenge_Odontoprev_ADB.Models.Entities;

namespace Challenge_Odontoprev_ADB.Repositories.Interfaces;

public interface IDoctorRepository : _IRepository<Doctor>
{
    Task<Doctor> GetDoctorByNameAsync(string name);
}
