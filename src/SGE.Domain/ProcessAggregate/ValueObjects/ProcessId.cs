using SGE.Domain.Common.Models;

namespace SGE.Domain.ProcessAggregate.ValueObjects;

public sealed class ProcessId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private ProcessId(Guid value)
    {
        this.Value = value;
    }

    public static ProcessId Create(Guid value)
    {
        return new ProcessId(value);
    }

    public static ProcessId CreateUnique()
    {
        return new ProcessId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}