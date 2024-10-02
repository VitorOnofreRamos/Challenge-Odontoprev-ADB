using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

[Owned]
public class Cost
{
    public decimal Amount { get; private set; }

    private Cost() { }

    private Cost(decimal amount) {
        if (amount < 0)
            throw new ArgumentException("Price cannot be negative.");

        Amount = amount; 
    }

    public static implicit operator decimal(Cost value) => value.Amount;

    public override string ToString() => $"R$ {Amount:F2}";
}
