using FitnessTracker.Domain.Users;
using FitnessTracker.Domain.Users.Events;
using FluentAssertions;
using static FitnessTracker.Domain.Users.User;

namespace FitnessTracker.Domain.UnitTests.User;

public class UserTests
{
    private Users.User CreateValidUser()
    {
        var userId = new UserId(Ulid.NewUlid());
        var name = Name.Create("Jan", "Kowalski");
        var email = Email.Create("jan.kowalski@gmail.com");
        
        return Create(userId,name.Value,email.Value);
    }
    
    [Fact]
    public void Create_User_ShouldNotBeNull()
    {
        var user = CreateValidUser();
        user.Should().NotBeNull();
    }
    
    [Fact]
    public void Create_User_ShouldRaiseUserCreatedDomainEvent()
    {
        var user = CreateValidUser();
        user.DomainEvents.Should()
            .NotBeNull()
            .And.NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainItemsAssignableTo<UserCreatedDomainEvent>();
    }
}