using SharedKernel.Events;

namespace SharedKernel.Entities;

public interface IEntity
{
    public Ulid Id { get; set; }
}