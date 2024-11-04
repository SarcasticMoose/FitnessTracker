using FitnessTracker.Domain.Users;
using FluentResults;

namespace FitnessTracker.Domain.Followers;

public interface IFollowerRepository
{
    Task<bool> IsUserFollowedAsync(UserId userId, UserId followerId, CancellationToken ct = default);
    Task<Result> Insert(Follower follower,CancellationToken ct = default);
    Task<Follower> GetFollowerById(UserId userId,UserId followerId,CancellationToken ct = default);
    Task<Result> Delete(FollowerId follower, CancellationToken ct = default);
}