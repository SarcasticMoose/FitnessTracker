using SharedKernel.Events;

namespace SharedKernel.Entities;

public abstract class Entity<TId>(TId id) : IEntity<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public TId Id { get; } = id;
    
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

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
}