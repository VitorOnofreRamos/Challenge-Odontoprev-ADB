using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class AppointmentLocation
{
    public string City { get; private set; }
    public string State { get; private set; }

    private AppointmentLocation() {}
    
    public AppointmentLocation(string city, string state)
    {
        City = city;
        State = state;
    }

    public string GetFullAddress() => $"{City}, {State}";

    public override string ToString() => GetFullAddress();
}
