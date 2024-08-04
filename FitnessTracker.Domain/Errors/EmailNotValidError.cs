using FluentResults;

namespace FitnessTracker.Domain.Errors;

public class EmailNotValidError : Error
{
    private readonly string? _email;

    public EmailNotValidError(string? email)
    {
        _email = email;
        CausedBy($"Email {email} is invalid");
    }
}