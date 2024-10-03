using Challenge_Odontoprev_ADB.Repositories;
using Challenge_Odontoprev_ADB.Repositories.Implementations;
using Challenge_Odontoprev_ADB.Repositories.Interfaces;

namespace Challenge_Odontoprev_ADB.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IAppointmentRepository Appointment {  get; private set; }
    public IDoctorRepository Doctor { get; private set; }
    public IPatientRepository Patient { get; private set; }
    public ITreatmentRepository Treatment { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Appointment = new AppointmentRepository(_context);
        Doctor = new DoctorRepository(_context);
        Patient = new PatientRepository(_context);
        Treatment = new TreatmentRepository(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
