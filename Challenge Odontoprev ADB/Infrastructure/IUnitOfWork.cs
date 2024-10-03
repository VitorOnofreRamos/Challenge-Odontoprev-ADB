using Challenge_Odontoprev_ADB.Repositories.Interfaces;

namespace Challenge_Odontoprev_ADB.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IAppointmentRepository Appointment { get; }
    IDoctorRepository Doctor { get; }
    IPatientRepository Patient { get; }
    ITreatmentRepository Treatment { get; }

    Task<int> CompleteAsync();
}