using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
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
