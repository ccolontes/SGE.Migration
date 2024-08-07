using SGE.Domain.Common.Interfaces.Persistence;
using SGE.Domain.Common.Models;
using SGE.Domain.ProcedureAggregate.ValueObjects;
using SGE.Domain.ProcessAggregate.ValueObjects;

namespace SGE.Domain.ProcessAggregate;

public sealed class Process : AggregateRoot<ProcessId, Guid>, ISoftDeletable
{
    private readonly List<ProcedureId> _proceduresIds = [];
    public string Name { get; private set; }

    public Process(ProcessId Id, string name)
    {
        this.Id = Id;
        this.Name = name;
    }

    public IReadOnlyList<ProcedureId> ProceduresIds => _proceduresIds.AsReadOnly();

    public static Process Create(Guid id, string name)
    {
        return new Process(ProcessId.Create(id), name);
    }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOnUtc { get; set; }

    #pragma warning disable CS8618
    private Process()
    {
    }
    #pragma warning restore CS8618
}