using SGE.Domain.Common.Interfaces;
using SGE.Domain.Common.Interfaces.Persistence;
using SGE.Domain.Common.Models;
using SGE.Domain.ProcessAggregate.Entities;

namespace SGE.Domain.ProcessAggregate;

public class Process(string id, string name) : AggregateRoot<string>(id), ISoftDeletable
{
    public string Name { get; protected set; } = name;

    private List<Procedure> _procedures = [];

    public IReadOnlyList<Procedure> Procedures => _procedures.AsReadOnly();

    public static Process Create(string id, string name)
    {
        return new Process(id, name);
    }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOnUtc { get; set; }
}