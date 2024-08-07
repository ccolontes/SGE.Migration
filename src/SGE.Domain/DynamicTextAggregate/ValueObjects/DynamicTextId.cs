using SGE.Domain.Common.Models;

namespace SGE.Domain.DynamicTextAggregate.ValueObjects;

public class DynamicTextId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private DynamicTextId(Guid value)
    {
        this.Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static DynamicTextId CreateUnique()
    {
        return new DynamicTextId(Guid.NewGuid());
    }

    public static DynamicTextId Create(Guid value)
    {
        return new DynamicTextId(value);
    }
}