namespace SharedKernel.Events;

public interface IDomainEvent
{
    public Guid Id { get; }
    public DateTime CreationDate { get; }
}