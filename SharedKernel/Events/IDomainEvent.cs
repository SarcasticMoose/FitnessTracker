namespace SharedKernel.Events;

public interface IDomainEvent
{
    public Ulid Id { get; }
}