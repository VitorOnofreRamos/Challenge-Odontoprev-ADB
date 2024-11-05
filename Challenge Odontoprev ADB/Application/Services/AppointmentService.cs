using Challenge_Odontoprev_ADB.Models.Entities;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;

namespace Challenge_Odontoprev_ADB.Application.Services;

public class AppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Appointment> GetAppointmentByIdAsync(int id) =>
        await _appointmentRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync() =>
        await _appointmentRepository.GetAllAsync();

    public async Task AddAppointmentAsync(Appointment appointment) =>
        await _appointmentRepository.AddAsync(appointment);

    public async Task UpdateAppointmentAsync(Appointment appointment) =>
        await _appointmentRepository.UpdateAsync(appointment);

    public async Task RemoveAppointmentAsync(int id) =>
        await _appointmentRepository.RemoveAsync(id);
}
