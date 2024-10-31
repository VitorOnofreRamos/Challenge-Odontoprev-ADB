using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Repositories.Implementations;

public class AppointmentRepository : _Repository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Appointment> GetAppointmetByLocationAsync(AppointmentLocation location)
    {
        return await _context.Appointments.FirstOrDefaultAsync(c => c.Location == location);
    }

    public async Task<Appointment> GetAppointmetByDateAsync(FutureDate date)
    {
        return await _context.Appointments.FirstOrDefaultAsync(c => c.Date == date);
    }
}
