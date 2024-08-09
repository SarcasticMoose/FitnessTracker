using FitnessTracker.Domain.Users;
using FluentResults;

namespace FitnessTracker.Domain.Followers;

public interface IFollowerService
{
    Task<Result> StartFollowUserAsync(User user, User follower, CancellationToken ct = default);
}