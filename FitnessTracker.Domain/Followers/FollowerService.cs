using FitnessTracker.Domain.Users;
using FluentResults;

namespace FitnessTracker.Domain.Followers;

public sealed class FollowerService : IFollowerService
{
    private readonly IFollowerRepository _followerRepository;

    public FollowerService(IFollowerRepository followerRepository)
    {
        _followerRepository = followerRepository;
    }

    public async Task<Result> StartFollowUserAsync(User user, User follower, CancellationToken ct = default)
    {
        if (user.Id == follower.Id)
        {
            return FollowerErrors.UserAndFollowerIdEquals();
        }

        if (await _followerRepository.IsUserFollowedAsync(user.Id, follower.Id, ct))
        {
            return FollowerErrors.UserIsFollowed();
        }

        var newFollower = Follower.Create(user.Id, follower.Id,DateTime.Now);

        return Result.Ok();
    }
}