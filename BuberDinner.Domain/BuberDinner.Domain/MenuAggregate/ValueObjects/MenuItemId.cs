using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public class MenuItemId : ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}