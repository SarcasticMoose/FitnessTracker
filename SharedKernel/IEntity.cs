using SharedKernel.Events;

namespace SharedKernel;

public interface IEntity<out TId>
{
    public TId Id { get; }
}

public abstract class Entity<TId>(TId id) : IEntity<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public TId Id { get; } = id;

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    protected void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    protected void RemoveDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }
}

