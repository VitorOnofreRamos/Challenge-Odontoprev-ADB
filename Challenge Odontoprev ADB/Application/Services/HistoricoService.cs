using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class HistoricoService
{
	private readonly _IRepository<HistoricoConsulta> _repository;

	public HistoricoService(_IRepository<HistoricoConsulta> repository)
	{
		_repository = repository;
	}

	public async Task<HistoricoConsulta> GetHistoricoByIdAsync(long id) =>
		await _repository.GetById(id);

	public async Task<IEnumerable<HistoricoConsulta>> GetAllHistoricosAsync() =>
		await _repository.GetAll();

	public async Task AddHistoricoAsync(HistoricoConsulta entity) =>
		await _repository.Insert(entity);

	public async Task UpdateHistoricoAsync(HistoricoConsulta entity) =>
		await _repository.Update(entity);

	public async Task RemoveHistoricoAsync(long id) =>
		await _repository.Delete(id);
}
