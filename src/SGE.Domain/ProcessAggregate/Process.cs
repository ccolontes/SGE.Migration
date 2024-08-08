using SGE.Domain.Common.Interfaces.Persistence;
using SGE.Domain.Common.Models;
using SGE.Domain.ProcedureAggregate.ValueObjects;
using SGE.Domain.ProcessAggregate.ValueObjects;

namespace SGE.Domain.ProcessAggregate;

public sealed class Process : AggregateRoot<ProcessId>, ISoftDeletable
{
    private readonly List<ProcedureId> _proceduresIds = [];
    public string Name { get; private set; }

    public Process(ProcessId Id, string name, List<ProcedureId> proceduresIds)
    {
        this.Id = Id;
        this.Name = name;
        this._proceduresIds = proceduresIds;
    }

    public IReadOnlyList<ProcedureId> ProceduresIds => _proceduresIds.AsReadOnly();

    public static Process Create(Guid id, string name, List<ProcedureId>? proceduresIds = null)
    {
        return new Process(ProcessId.Create(id), name, proceduresIds ?? new());
    }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOnUtc { get; set; }

    #pragma warning disable CS8618
    private Process()
    {
    }
    #pragma warning restore CS8618
}