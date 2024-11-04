using MediatR;

namespace SharedKernel.Events;

public interface IDomainEvent : INotification
{
    public Ulid Id { get; }
}