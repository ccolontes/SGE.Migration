using SGE.Domain.Common.Interfaces.Models;

namespace SGE.Domain.Common.Models;

public abstract class AggregateRoot<TId>(TId id) : Entity<TId>(id)
    where TId : notnull
{
     protected readonly List<IDomainEvent> _domainEvents = [];

     public void AddDomainEvent(IDomainEvent domainEvent)
     {
         _domainEvents.Add(domainEvent);
     }

     public List<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents.ToList();
        _domainEvents.Clear();

        return copy;
    }
}