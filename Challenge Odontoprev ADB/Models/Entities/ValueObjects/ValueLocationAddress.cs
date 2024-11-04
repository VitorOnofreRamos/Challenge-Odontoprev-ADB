using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class ValueLocationAddress
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }

    private ValueLocationAddress() {}
    
    public ValueLocationAddress(string street, string city, string state)
    {
        Street = street;
        City = city;
        State = state;
    }

    public string GetFullAddress() => $"{Street}, {City}, {State}";

    public override string ToString() => GetFullAddress();
}
