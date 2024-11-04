using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

namespace Challenge_Odontoprev_ADB.Repositories.Interfaces;

public interface IAppointmentRepository : _IRepository<Appointment>
{
    Task<Appointment> GetAppointmetByAddressAsync(ValueLocationAddress address);
    Task<Appointment> GetAppointmetByDateAsync(ValueAppointmentDate date);
}
