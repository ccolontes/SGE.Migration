using System.ComponentModel.DataAnnotations.Schema;

using SGE.Domain.Common.Models;
using SGE.Domain.ProcedureAggregate.ValueObjects;

namespace SGE.Domain.ProcedureAggregate;

public sealed class Procedure : AggregateRoot<ProcedureId>
{
    public string Name { get; private set; }

    private readonly List<ProcedureId> _proceduresIds = [];

    [NotMapped]
    public IReadOnlyList<ProcedureId> ProceduresIds => _proceduresIds.AsReadOnly();

    private Procedure(ProcedureId id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

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