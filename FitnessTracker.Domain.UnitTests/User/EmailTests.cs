using FitnessTracker.Domain.Users;
using FluentAssertions;
using FluentResults;

namespace FitnessTracker.Domain.UnitTests.User;

public class EmailTests
{
    [Theory]
    [InlineData("testEmail")]
    [InlineData("testEmail@")]
    [InlineData("testEmail@wp.")]
    [InlineData("testEmail@wp.p")]
    public void Email_WithInvalidButNotNullValue_ShouldReturnFailedAndHaveEmailNotValidError(string email)
    {
        var emailString = Email.Create(email);

        emailString
            .Errors.Should()
            .ContainSingle(error => error is Error)
            .Which.Message.Should().Be(EmailErrors.EmailInvalidPattern(email).Message);
        emailString.IsFailed.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Email_NullValue_ShouldReturnFailedAndHaveNullOrEmptyError(string email)
    {
        var emailString = Email.Create(email);

        emailString
            .Errors.Should()
            .ContainSingle(error => error is Error)
            .Which.Message.Should().Be(EmailErrors.EmailNullOrEmpty().Message);
        emailString.IsFailed.Should().BeTrue();
    }
}