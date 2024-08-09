using FitnessTracker.Domain.Followers.Events;
using FitnessTracker.Domain.Users;
using SharedKernel.Entities;

namespace FitnessTracker.Domain.Followers;

public sealed class Follower : Entity
{
    public UserId UserId { get; private set; }

    public UserId FollowedId { get; private set; }

    public DateTime CreatedOn { get; private set; }

    private Follower(UserId userId, UserId followedId, DateTime createdOn)
    {
        UserId = userId;
        FollowedId = followedId;
        CreatedOn = createdOn;
    }

    internal static Follower Create(UserId userId, UserId followedId, DateTime createOnUtc)
    {
        var follower = new Follower(userId, followedId, createOnUtc);
        follower.RaiseDomainEvent(new FollowerCreatedDomainEvent(userId, followedId));
        return follower;
    }
}