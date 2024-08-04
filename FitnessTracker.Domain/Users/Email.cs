using System.Text.RegularExpressions;
using FitnessTracker.Domain.Errors;
using FluentResults;
using SharedKernel.Errors;

namespace FitnessTracker.Domain.Users;

public record Email
{
    private const string EmailRegexPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    public string Value { get; private set; }
    private static bool IsEmailValid(string email) => Regex.Matches(email, EmailRegexPattern, RegexOptions.IgnoreCase).Count > 0;

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return Result.Fail(new NullOrEmptyError(nameof(email)));
        }
        
        if (!IsEmailValid(email))
        {
            return Result.Fail(new EmailNotValidError(email));
        }

        return Result.Ok(new Email(email));
    }
    private Email(string value)
    {
        Value = value;
    }
}