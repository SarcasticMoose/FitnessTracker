using SharedKernel.Events;

namespace SharedKernel.Entities;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
}