using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class PassDate
{
    public DateTime Date { get; private set; }

    private PassDate() { }

    public PassDate(DateTime date)
    {
        if (date > DateTime.Now)
            throw new ArgumentException("Event date cannot be in the future.");
        Date = date;
    }
}
