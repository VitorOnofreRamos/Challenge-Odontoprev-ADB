using Challenge_Odontoprev_ADB.Models.Entities;
using System.Linq.Expressions;

namespace Challenge_Odontoprev_ADB.Repositories.Interfaces;

public interface _IRepository<T> where T : _BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
