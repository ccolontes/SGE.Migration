using SGE.Domain.Common.Models;
using SGE.Domain.ProcedureAggregate;

namespace SGE.Domain.ProcessAggregate.Entities;

public class ProcessProcedure
{
    public AggregateRootId<Ulid> ProcedureId { get; set; } = null!;
    public Process? Process { get; set; }

    public AggregateRootId<Ulid> ProcessId { get; set; } = null!;
    public Procedure? Procedure { get; set; }
}