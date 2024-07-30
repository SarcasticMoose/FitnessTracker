using SharedKernel.Events;

namespace FitnessTracker.Domain.Events;

public class UserCreatedDomainEvent() : IDomainEvent
{
    public Guid Id { get; } = new Guid();
    public DateTime CreationDate { get; } = DateTime.Now;
}