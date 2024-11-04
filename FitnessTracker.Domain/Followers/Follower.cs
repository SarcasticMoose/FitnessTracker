using FitnessTracker.Domain.Followers.Events;
using FitnessTracker.Domain.Users;
using SharedKernel.Aggregates;
using SharedKernel.Entities;

namespace FitnessTracker.Domain.Followers;

public sealed class Follower : AggregateRoot
{
    public FollowerId Id { get; private set; }
    public FolloweeId FolloweeId { get; private set; }
    public DateTime CreatedOn { get; private set; }

    private Follower(FollowerId followerId, FolloweeId followeeId, DateTime createdOn)
    {
        Id = followerId;
        FolloweeId = followeeId;
        CreatedOn = createdOn;
    }

    internal static Follower Create(FollowerId followerId, FolloweeId followeeId, DateTime createOnUtc)
    {
        var follower = new Follower(followerId,followeeId, createOnUtc);
        follower.RaiseDomainEvent(new FollowerCreatedDomainEvent(followerId, followeeId));
        return follower;
    }
}

public record FollowerId(Ulid Id);
public record FolloweeId(Ulid Id);