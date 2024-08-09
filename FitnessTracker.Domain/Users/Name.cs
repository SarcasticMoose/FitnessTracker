using FluentResults;

namespace FitnessTracker.Domain.Users;

public record Name
{
    public string FirstName { get; private set; }
    
    public string? MiddleName { get; private set; }
    
    public string Surname { get; private set; }

    public string Fullname => MiddleName is null ? $"{FirstName} {Surname}" : $"{FirstName} {MiddleName} {Surname}";

    public static Result<Name> Create(string firstName, string secondName,string? middleName = null)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            return Result.Fail(NameErrors.FirstnameNullOrEmpty());
        }
        
        if (string.IsNullOrEmpty(secondName))
        {
            return Result.Fail(NameErrors.SurnameNullOrEmpty());
        }
        
        if (string.IsNullOrEmpty(middleName))
        {
            return Result.Ok(new Name(firstName, secondName));
        }
        
        return Result.Ok(new Name(firstName, middleName, secondName));
    }
    
    private Name(string firstName, string surname)
    {
        FirstName = firstName;
        Surname = surname;
    }
    
    private Name(string firstName, string middleName, string surname)
    {
        FirstName = firstName;
        Surname = surname;
        MiddleName = middleName;
    }
}