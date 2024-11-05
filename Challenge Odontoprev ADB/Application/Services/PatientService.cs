using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class PatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Patient> GetPatientByIdAsync(int id) =>
        await _patientRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync() =>
        await _patientRepository.GetAllAsync();

    public async Task AddPatientAsync(Patient patient) =>
        await _patientRepository.AddAsync(patient);

    public async Task UpdatePatientAsync(Patient patient) =>
        await _patientRepository.UpdateAsync(patient);

    public async Task RemovePatientAsync(int id) =>
        await _patientRepository.RemoveAsync(id);
}
