using FluentResults;
using SharedKernel.Errors;

namespace FitnessTracker.Domain.Users;

public record Name
{
    public string FirstName { get; private set; }
    public string SecondName { get; private set; }

    public static Result<Name> Create(string firstName, string secondName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            return Result.Fail(new NullOrEmptyError(nameof(firstName)));
        }
        if (string.IsNullOrEmpty(secondName))
        {
            return Result.Fail(new NullOrEmptyError(nameof(secondName)));
        }
        return Result.Ok(new Name(firstName, secondName));
    }
    
    private Name(string firstName, string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }
}