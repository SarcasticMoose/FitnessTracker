using System.Text.RegularExpressions;
using FluentResults;
using SharedKernel;

namespace FitnessTracker.Domain.Users;

public record Email
{
    private const string EmailRegexPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    public string Value { get; private set; }

    private static bool IsEmailValid(string email) =>
        Regex.Matches(email, EmailRegexPattern, RegexOptions.IgnoreCase).Count > 0;

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return Result.Fail(EmailErrors.EmailNullOrEmpty());
        }

        if (!IsEmailValid(email))
        {
            return Result.Fail(EmailErrors.EmailInvalidPattern(email));
        }

        return Result.Ok(new Email(email));
    }

    private Email(string value)
    {
        Value = value;
    }
}