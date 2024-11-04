using SharedKernel.Events;

namespace SharedKernel.Aggregates;

public abstract class AggregateRoot : IAggregateRoot
{
    private IList<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected void ClearDomainEvents()
    {
        _domainEvents.Clear(); 
    }
}