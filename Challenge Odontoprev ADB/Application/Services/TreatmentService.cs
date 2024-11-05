using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class TreatmentService
{
    private readonly ITreatmentRepository _treatmentRepository;

    public TreatmentService(ITreatmentRepository treatmentRepository)
    {
        _treatmentRepository = treatmentRepository;
    }

    public async Task<Treatment> GetTreatmentByIdAsync(int id) =>
        await _treatmentRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Treatment>> GetAllTreatmentsAsync() =>
        await _treatmentRepository.GetAllAsync();

    public async Task AddTreatmentAsync(Treatment treatment) =>
        await _treatmentRepository.AddAsync(treatment);

    public async Task UpdateTreatmentAsync(Treatment treatment) =>
        await _treatmentRepository.UpdateAsync(treatment);

    public async Task RemoveTreatmentAsync(int id) =>
        await _treatmentRepository.RemoveAsync(id);
}
