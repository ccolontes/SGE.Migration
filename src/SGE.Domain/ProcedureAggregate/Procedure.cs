using SGE.Domain.Common.Models;
using SGE.Domain.ProcedureAggregate.ValueObjects;
using SGE.Domain.ProcessAggregate;
using SGE.Domain.ProcessAggregate.ValueObjects;

namespace SGE.Domain.ProcedureAggregate;

public sealed class Procedure : AggregateRoot<ProcedureId, Guid>
{
    private readonly List<ProcessId> _processesIds = [];
    public string Name { get; private set; }

    public Procedure(ProcedureId id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public IReadOnlyList<ProcessId> ProcessesIds => _processesIds.AsReadOnly();

    public static Procedure Create(Guid id, string name)
    {
        return new Procedure(ProcedureId.Create(id), name);
    }

    #pragma warning disable CS8618
    private Procedure()
    {
    }
    #pragma warning restore CS8618
}