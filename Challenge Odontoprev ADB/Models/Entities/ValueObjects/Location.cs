using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class Location
{
    public string City { get; private set; }
    public string State { get; private set; }

    private Location() {}

    public Location(string city, string state)
    {
        City = city;
        State = state;
    }
}
