﻿using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Repositories.Implementations;

public class AppointmentRepository : _Repository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Appointment> GetAppointmetByDateAsync(DateTime date)
    {
        return await _context.Appointments.FirstOrDefaultAsync(c => c.AppointmentDate == date);
    }
}
