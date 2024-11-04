using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class ValueCost
{
    public decimal Amount { get; private set; }

    private ValueCost() { }

    public ValueCost(decimal amount) {
        if (amount < 0)
            throw new ArgumentException("Price cannot be negative.");

        Amount = amount; 
    }

    public static implicit operator decimal(ValueCost value) => value.Amount;

    public override string ToString() => $"R$ {Amount:F2}";
}
