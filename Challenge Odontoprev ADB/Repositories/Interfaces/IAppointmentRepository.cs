using Challenge_Odontoprev_ADB.Models.Entities;
namespace Challenge_Odontoprev_ADB.Repositories.Interfaces;

public interface IAppointmentRepository : _IRepository<Appointment>
{
    Task<Appointment> GetAppointmetByDateAsync(DateTime date);
}
