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

    public async Task<Result> StartFollowingUserAsync(User user, User follower, CancellationToken ct = default)
    {
        if (user.Id == follower.Id)
        {
            return FollowerErrors.UserAndFollowerIdEquals();
        }

        if (await _followerRepository.IsUserFollowedAsync(user.Id, follower.Id, ct))
        {
            return FollowerErrors.UserIsFollowed();
        }

        return await _followerRepository.Insert(Follower.Create(user.Id, follower.Id, DateTime.Now),ct);
    }

    public async Task<Result> StopFollowingUserAsync(User user, User follower, CancellationToken ct = default)
    {
        if (user.Id == follower.Id)
        {
            return FollowerErrors.UserAndFollowerIdEquals();
        }

        if (!await _followerRepository.IsUserFollowedAsync(user.Id, follower.Id, ct))
        {
            return FollowerErrors.UserIsNotFollowed();
        }

        Follower followerGetResult  = await _followerRepository.GetFollowerById(user.Id,follower.Id,ct);
        return await _followerRepository.Delete(new FollowerId(followerGetResult.Id.Id));
    }
}