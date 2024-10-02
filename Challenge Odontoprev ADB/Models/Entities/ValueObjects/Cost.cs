namespace Challenge_Odontoprev_ADB.Models.Entities.ValueObjects;

public class Amount
{
    public decimal Value { get; private set; }

    private Amount() { }

    private Amount(decimal value) {
        if (value < 0)
            throw new ArgumentException("Price cannot be negative.");
        Value = value; 
    }
}
