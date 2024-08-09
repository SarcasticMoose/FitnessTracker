using SharedKernel.Events;

namespace FitnessTracker.Domain.Events;

public record UserCreatedDomainEvent : IDomainEvent
{
    public Ulid Id { get; } = new();
}