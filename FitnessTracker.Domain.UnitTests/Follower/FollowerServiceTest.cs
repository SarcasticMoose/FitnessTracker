using FitnessTracker.Domain.Followers;
using FitnessTracker.Domain.Users;
using FluentAssertions;
using FluentResults;
using NSubstitute;

namespace FitnessTracker.Domain.UnitTests.Follower;

public class FollowerServiceTest
{
    private User CreateValidUser()
    {
        var userId = new UserId();
        var name = Name.Create("Jan", "Kowalski");
        var email = Email.Create("jan.kowalski@gmail.com");
        
        return User.Create(userId,name.Value,email.Value);
    }
    
    [Fact]
    public async Task StartFollowUser_FollowYourself_ShouldReturnResultFail()
    {
        var user = CreateValidUser();
        var userToFollow = user;
        var followerRepository = Substitute.For<IFollowerRepository>();
        var followService = new FollowerService(followerRepository);
        
        var result = await followService.StartFollowingUserAsync(user, userToFollow);
        
        result.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public async Task StartFollowUser_FollowCurrentlyFollowedUser_ShouldReturnResultFail()
    {
        var user = CreateValidUser();
        var userToFollow = CreateValidUser();
        var followerRepository = Substitute.For<IFollowerRepository>();
        var followService = new FollowerService(followerRepository);
        
        followerRepository.IsUserFollowedAsync(Arg.Is(user.Id), Arg.Is(userToFollow.Id)).Returns(true);
        var result = await followService.StartFollowingUserAsync(user, userToFollow);
        
        result.IsFailed.Should().BeTrue();
    }
    [Fact]
    public async Task StartFollowUser_CorrectFollow_ShouldReturnTrue()
    {
        var user = CreateValidUser();
        var userToFollow = CreateValidUser();
        var followerRepository = Substitute.For<IFollowerRepository>();
        var followService = new FollowerService(followerRepository);
        
        followerRepository.IsUserFollowedAsync(Arg.Is(user.Id), Arg.Is(userToFollow.Id)).Returns(false);
        followerRepository.Insert(Arg.Any<Followers.Follower>()).Returns(Result.Ok());
        var result = await followService.StartFollowingUserAsync(user, userToFollow);
        
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task StopFallowingUser_UnfollowUserThatWasNotFollowed_ShouldReturnResultTrue()
    {
        var user = CreateValidUser();
        var userToUnfollow = CreateValidUser();
        var followerRepository = Substitute.For<IFollowerRepository>();
        var followService = new FollowerService(followerRepository);
        followerRepository.IsUserFollowedAsync(Arg.Is(user.Id), Arg.Is(userToUnfollow.Id)).Returns(false);
        followerRepository.Insert(Arg.Any<Followers.Follower>()).Returns(Result.Ok());
        _ = await followService.StartFollowingUserAsync(user, userToUnfollow);
        
        var result = await followService.StopFollowingUserAsync(user, userToUnfollow);
        
        result.IsSuccess.Should().BeFalse();
        result.Errors.First().Message.Should().BeSameAs(FollowerErrors.UserIsNotFollowed().Message);
    }
}                   