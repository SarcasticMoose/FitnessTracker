using FitnessTracker.Domain.Events;
using FitnessTracker.Domain.Users;
using FluentAssertions;
using static FitnessTracker.Domain.Users.User;

namespace FitnessTracker.Domain.UnitTests.User;

public class UserTests
{
    private Users.User CreateValidUser()
    {
        var name = Name.Create("Jan", "Kowalski");
        var email = Email.Create("jan.kowalski@gmail.com");
        var id = Ulid.NewUlid();
        
        return Create(id,name.Value,email.Value);
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
        user.DomainEvents
            .Should()
            .NotBeNull()
            .And.NotBeEmpty()
            .And.HaveCount(1)
            .And.ContainItemsAssignableTo<UserCreatedDomainEvent>();
    }
}