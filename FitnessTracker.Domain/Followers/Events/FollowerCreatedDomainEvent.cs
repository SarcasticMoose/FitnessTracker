using FitnessTracker.Domain.Users;
using SharedKernel.Events;

namespace FitnessTracker.Domain.Followers.Events;

public class FollowerCreatedDomainEvent : DomainEvent
{
    public FollowerCreatedDomainEvent(FollowerId followerId, FolloweeId followeeId)
    {
        FollowerId = followerId;
        FolloweeId = followeeId;
    }
    
    public FollowerId FollowerId { get; private set; }
    public FolloweeId FolloweeId { get; private set; }
}