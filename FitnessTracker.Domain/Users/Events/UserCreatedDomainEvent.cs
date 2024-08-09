using SharedKernel.Events;

namespace FitnessTracker.Domain.Users.Events;

public record UserCreatedDomainEvent : IDomainEvent
{
    public Ulid Id { get; } = new();
    public DateTime CreatedOnUTC { get; } = DateTime.Now;
}