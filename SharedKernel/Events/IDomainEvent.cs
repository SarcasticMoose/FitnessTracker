namespace SharedKernel.Events;

public interface IDomainEvent
{
    public Ulid Id { get; }
    public DateTime CreationDate { get; }
}