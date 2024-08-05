namespace SGE.Domain.ProcessAggregate.Entities;

public class ProcessProcedure
{
    public string ProcedureId { get; set; } = null!;
    public Procedure? Procedure { get; set; }

    public string ProcessId { get; set; } = null!;

    public Process? Process { get; set; }
}
