﻿using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories.Implementations;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class AppointmentService
{
    private readonly AppointmentRepository _appointmentRepository;

    public AppointmentService(AppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Appointment> GetAppointmentByIdAsync(int id) =>
        await _appointmentRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync() =>
        await _appointmentRepository.GetAllAsync();

    public async Task AddAppointmentAsync(Appointment appointment) =>
        await _appointmentRepository.AddAsync(appointment);

    public async Task UpdateAppointmentAsync(Appointment consulta) =>
        await _appointmentRepository.UpdateAsync(consulta);

    public async Task RemoveAppointmentAsync(int id) =>
        await _appointmentRepository.RemoveAsync(id);

}
