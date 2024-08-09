using FitnessTracker.Domain.Users;
using SharedKernel.Events;

namespace FitnessTracker.Domain.Followers.Events;

public class FollowerCreatedDomainEvent : IDomainEvent
{
    public FollowerCreatedDomainEvent(UserId userId, UserId followedId)
    {
        UserId = userId;
        FollowedId = followedId;
    }

    public Ulid Id { get; } = Ulid.NewUlid();
    public DateTime CreatedOnUTC { get; } = DateTime.Now;
    public UserId UserId { get; private set; }
    public UserId FollowedId { get; private set; }
}