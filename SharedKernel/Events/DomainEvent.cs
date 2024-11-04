namespace SharedKernel.Events;

public abstract class DomainEvent : IDomainEvent 
{
    public Ulid Id { get; } = Ulid.NewUlid();
}