using Challenge_Odontoprev_ADB.Models.Entities;

namespace Challenge_Odontoprev_ADB.Repositories.Interfaces;

public interface IPatientRepository : _IRepository<Patient>
{
    Task<Patient> GetPatientByIdAsync(int id);
    Task<Patient> GetPatientByNameAsync(string name);
}
