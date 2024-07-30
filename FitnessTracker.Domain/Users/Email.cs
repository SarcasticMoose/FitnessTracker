using System.Text.RegularExpressions;

namespace FitnessTracker.Domain.Users;

public record Email
{
    private const string EmailRegexPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    private bool IsEmailValid(string email) => Regex.Matches(email, EmailRegexPattern, RegexOptions.IgnoreCase).Count > 0;
    public string EmailValue { get; private set; }

    public Email(string emailValue)
    {
        if (string.IsNullOrEmpty(emailValue))
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(emailValue));
        }
        
        if (!IsEmailValid(emailValue))
        {
            throw new ArgumentException("Email have not correct pattern", nameof(emailValue));
        }
        EmailValue = emailValue;
    }
}