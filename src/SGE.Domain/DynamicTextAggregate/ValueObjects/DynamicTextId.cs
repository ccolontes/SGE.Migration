using SGE.Domain.Common.Models;

namespace SGE.Domain.DynamicTextAggregate.ValueObjects;

public class DynamicTextId : ValueObject
{
    public Ulid Value { get; private set; }

    public DynamicTextId(Ulid value)
    {
        this.Value = value;
    }

    public static DynamicTextId CreateUnique()
    {
        return new DynamicTextId(Ulid.NewUlid());
    }

    public static DynamicTextId Create(string value)
    {
        return new DynamicTextId(Ulid.Parse(value));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}