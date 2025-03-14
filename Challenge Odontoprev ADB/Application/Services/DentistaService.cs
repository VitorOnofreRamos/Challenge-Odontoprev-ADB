using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class DentistaService
{
	private readonly _IRepository<Dentista> _repository;

	public DentistaService(_IRepository<Dentista> repository)
	{
		_repository = repository;
	}

	public async Task<Dentista> GetDentistaByIdAsync(long id) =>
		await _repository.GetById(id);

	public async Task<IEnumerable<Dentista>> GetAllDentistasAsync() =>
		await _repository.GetAll();

	public async Task AddDentistaAsync(Dentista entity) =>
		await _repository.Insert(entity);

	public async Task UpdateDentistaAsync(Dentista entity) =>
		await _repository.Update(entity);

	public async Task RemoveDentistaAsync(long id) =>
		await _repository.Delete(id);
}
