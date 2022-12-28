using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public double? Value { get; private set; }
    
    public int NumRatings { get; private set; }

    private AverageRating(double? value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }
    
    public static AverageRating CreateNew(double? value = 0, int numRatings = 0)
    {
        return new(value, numRatings);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public void AddNewRating(Rating rating)
    {
        Value = (Value * NumRatings + rating.Value) / ++NumRatings;       
    }

    internal void RemoveRating(Rating rating)
    {
        Value = (Value * NumRatings - rating.Value) / --NumRatings;
    }
}