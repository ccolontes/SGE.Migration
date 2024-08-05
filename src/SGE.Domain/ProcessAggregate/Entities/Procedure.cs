using SGE.Domain.Common.Models;
namespace SGE.Domain.ProcessAggregate.Entities;

public class Procedure(string id, string name) : Entity<string>(id)
{
    public string Name { get; protected set; } = name;

    private List<Process> _processes = [];
    public IReadOnlyList<Process> Processes => _processes.AsReadOnly();

    public static Procedure Create(string id, string name) => new(id, name);
}
