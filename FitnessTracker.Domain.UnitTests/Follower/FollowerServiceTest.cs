using FitnessTracker.Domain.Followers;
using FitnessTracker.Domain.Users;
using FluentAssertions;
using NSubstitute;

namespace FitnessTracker.Domain.UnitTests.Follower;

public class FollowerServiceTest
{
    private Users.User CreateValidUser()
    {
        var userId = new UserId(Ulid.NewUlid());
        var name = Name.Create("Jan", "Kowalski");
        var email = Email.Create("jan.kowalski@gmail.com");
        
        return Users.User.Create(userId,name.Value,email.Value);
    }
    
    [Fact]
    public async Task StartFollowUser_FollowYourself_ShouldReturnResultFail()
    {
        var user = CreateValidUser();
        var follower = user;
        var followerRepository = Substitute.For<IFollowerRepository>();
        var followService = new FollowerService(followerRepository);
        
        var result = await followService.StartFollowUserAsync(user, follower);
        
        result.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public async Task StartFollowUser_FollowCurrentlyFollowedUser_ShouldReturnResultFail()
    {
        var user = CreateValidUser();
        var follower = CreateValidUser();
        var followerRepository = Substitute.For<IFollowerRepository>();
        var followService = new FollowerService(followerRepository);
        
        followerRepository.IsUserFollowedAsync(Arg.Is(user.Id), Arg.Is(follower.Id)).Returns(true);
        var result = await followService.StartFollowUserAsync(user, follower);
        
        result.IsFailed.Should().BeTrue();
    }
    [Fact]
    public async Task StartFollowUser_CorrectFollow_ShouldReturnTrue()
    {
        var user = CreateValidUser();
        var follower = CreateValidUser();
        var followerRepository = Substitute.For<IFollowerRepository>();
        var followService = new FollowerService(followerRepository);
        
        followerRepository.IsUserFollowedAsync(Arg.Is(user.Id), Arg.Is(follower.Id)).Returns(false);
        var result = await followService.StartFollowUserAsync(user, follower);
        
        result.IsSuccess.Should().BeTrue();
    }
    
}