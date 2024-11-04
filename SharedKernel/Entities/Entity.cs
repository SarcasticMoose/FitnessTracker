namespace SharedKernel.Entities;

public abstract class Entity : IEntity
{
    public Ulid Id { get; set; }
}