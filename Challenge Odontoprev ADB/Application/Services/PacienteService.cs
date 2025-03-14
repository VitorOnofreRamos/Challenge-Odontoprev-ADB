using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class PacienteService
{
    private readonly _IRepository<Paciente> _repository;

    public PacienteService(_IRepository<Paciente> repository)
    {
        _repository = repository;
    }

    public async Task<Paciente> GetPacienteByIdAsync(long id) =>
        await _repository.GetById(id);

    public async Task<IEnumerable<Paciente>> GetAllPacientesAsync() =>
        await _repository.GetAll();

    public async Task AddPacientetAsync(Paciente entity) =>
        await _repository.Insert(entity);

    public async Task UpdatePacienteAsync(Paciente entity) =>
        await _repository.Update(entity);

    public async Task RemovePacienteAsync(long id) =>
        await _repository.Delete(id);
}
