using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class ValueAppointmentDate
{
    public DateTime Date { get; private set; }

    private ValueAppointmentDate() {}

    public ValueAppointmentDate(DateTime date)
    {
        if (date < DateTime.Now)
            throw new ArgumentException("Event date cannot be in the past.");
        Date = date;
    }
}
