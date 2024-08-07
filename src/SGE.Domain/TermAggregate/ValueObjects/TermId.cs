using SGE.Domain.Common.Models;

namespace SGE.Domain.TermAggregate.ValueObjects;

public class TermId(Ulid value) : AggregateRootId<Ulid>
{
    public override Ulid Value { get; protected set; } = value;

    public static TermId Create(string value)
    {
        return new TermId(Ulid.Parse(value));
    }

    public static TermId CreateUnique()
    {
        return new TermId(Ulid.NewUlid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}