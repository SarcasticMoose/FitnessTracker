using SharedKernel.Events;

namespace SharedKernel.Entities;

public abstract class Entity : IEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    
    protected void RaiseDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    protected void ClearDomainEvent()
    {
        _domainEvents.Clear();
    }

    protected void RemoveDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Remove(eventItem);
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
}