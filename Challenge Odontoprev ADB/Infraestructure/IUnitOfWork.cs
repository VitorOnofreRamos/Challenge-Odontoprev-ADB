using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories;

namespace Challenge_Odontoprev_ADB.Infraestructure;

public interface IUnitOfWork : IDisposable
{
    _IRepository<_BaseEntity> _IRepository { get; }

    Task<int> CompleteAsync();
}