using FluentResults;

namespace FitnessTracker.Domain.Followers;

public static class FollowerErrors
{
    public static Error UserAndFollowerIdEquals() => new("Cannot follow yourself");

    public static Error UserIsFollowed() => new("Cannot follow currently followed user");

    public static Error UserIsNotFollowed() => new Error("Cannot unfollow user that is not followed");
}