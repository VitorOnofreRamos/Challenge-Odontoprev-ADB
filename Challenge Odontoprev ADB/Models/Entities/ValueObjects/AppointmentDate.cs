using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

public class AppointmentDate
{
    public DateTime Date { get; private set; }

    private AppointmentDate() {}

    public AppointmentDate(DateTime date)
    {
        if (date < DateTime.Now)
            throw new ArgumentException("Event date cannot be in the past.");
        Date = date;
    }
}
