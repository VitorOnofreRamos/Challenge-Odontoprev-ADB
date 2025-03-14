using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class ConsultaService
{
	private readonly _IRepository<Consulta> _repository;

	public ConsultaService(_IRepository<Consulta> repository)
	{
		_repository = repository;
	}

	public async Task<Consulta> GetConsultaByIdAsync(long id) =>
		await _repository.GetById(id);

	public async Task<IEnumerable<Consulta>> GetAllConsultasAsync() =>
		await _repository.GetAll();

	public async Task AddConsultaAsync(Consulta entity) =>
		await _repository.Insert(entity);

	public async Task UpdateConsultaAsync(Consulta entity) =>
		await _repository.Update(entity);

	public async Task RemoveConsultaAsync(long id) =>
		await _repository.Delete(id);
}
