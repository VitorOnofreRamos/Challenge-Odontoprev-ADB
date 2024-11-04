using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class ValueDateOfBirth
{
    public DateTime Date { get; private set; }

    private ValueDateOfBirth() { }

    public ValueDateOfBirth(DateTime date)
    {
        if (date > DateTime.Now)
            throw new ArgumentException("Event date cannot be in the future.");
        Date = date;
    }
}
