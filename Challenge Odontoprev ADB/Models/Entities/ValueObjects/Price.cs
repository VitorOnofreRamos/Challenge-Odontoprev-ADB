using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class Price
{
    public decimal Amount { get; private set; }

    private Price() {}

    public Price(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Price cannot be negative.");
        Amount = amount;
    }
}
