using FitnessTracker.Domain.Users;
using FluentResults;

namespace FitnessTracker.Domain.Followers;

public interface IFollowerRepository
{
    Task<bool> IsUserFollowedAsync(UserId userId, UserId followerId, CancellationToken ct = default);
    Task<Result> Insert(UserId followerId,CancellationToken ct = default);
}