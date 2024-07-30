using FitnessTracker.Domain.Users;
using FluentAssertions;

namespace FitnessTracker.Domain.UnitTests.User;

public class EmailTests
{
    [Theory]
    [InlineData("testEmail")]
    [InlineData("testEmail@")]
    [InlineData("testEmail@wp.")]
    [InlineData("testEmail@wp.p")]
    public void Email_WithInvalidButNotNullValue_ShouldThrowArgumentException(string email)
    {
        Action emailAction = () =>
        {
            _ = new Email(email);
        };
        emailAction.Should().Throw<ArgumentException>();
    }
    
    [Theory]
    [InlineData(null)]
    public void Email_WithInvalidNullValue_ShouldThrowArgumentException(string email)
    {
        Action emailAction = () =>
        {
            _ = new Email(email);
        };
        emailAction.Should().Throw<ArgumentNullException>();
    }
    
}