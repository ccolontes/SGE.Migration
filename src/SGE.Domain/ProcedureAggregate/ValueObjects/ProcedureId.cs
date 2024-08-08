using SGE.Domain.Common.Models;

namespace SGE.Domain.ProcedureAggregate.ValueObjects;

public sealed class ProcedureId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private ProcedureId(Guid value)
    {
        this.Value = value;
    }

    public static ProcedureId Create(Guid value)
    {
        return new ProcedureId(value);
    }

    public static ProcedureId CreateUnique()
    {
        return new ProcedureId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}