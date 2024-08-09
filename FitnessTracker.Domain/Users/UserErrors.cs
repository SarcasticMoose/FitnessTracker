using FluentResults;

namespace FitnessTracker.Domain.Users;

public static class EmailErrors
{
    public static Error EmailInvalidPattern(string email) => new($"Email {email} is invalid");
    
    public static Error EmailNullOrEmpty() => new($"Email cannot be null or empty");
    
    public static Error EmailInUse(string email) => new($"Email {email} is use by another user");
    
    public static Error EmailMissing(string email) => new($"Email {email} was not found");
}