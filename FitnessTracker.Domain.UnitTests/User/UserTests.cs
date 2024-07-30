using FitnessTracker.Domain.Events;
using FitnessTracker.Domain.Users;
using FluentAssertions;

namespace FitnessTracker.Domain.UnitTests.User;

public class UserTests
{
    private Users.User CreateValidUser()
    {
        return Users.User.Create(new Guid(), new Name("Jan", "Kowalski"), new Email("jan.kowalski@gmail.com"));
    }
    
    [Fact]
    public void Create_User_ShouldNotBeNull()
    {
        var user = CreateValidUser();
        user.Should().NotBeNull();
    }
    
    [Fact]
    public void Create_User_ShouldAddCreatedDomainEvent()
    {
        var user = CreateValidUser();
        user.DomainEvents.Should().NotBeNull()
            .And.NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainItemsAssignableTo<UserCreatedDomainEvent>();
    }
}