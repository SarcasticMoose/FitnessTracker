using SharedKernel.Events;

namespace SharedKernel.Aggregates;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
}