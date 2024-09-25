using Challenge_Odontoprev_ADB.Models.Entities;
using System.Linq.Expressions;

namespace Challenge_Odontoprev_ADB.Repositories;

public interface _IRepository<T> where T : _BaseEntity
{
    // TASK é um tipo de retorno que representa uma operação assíncrona
    // Async ele é usado no banco de dados para não travar a aplicação
    // porque ele não bloqueia a thread principal
    // Ele é usado para operações que podem demorar
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
