using FluentResults;

namespace FitnessTracker.Domain.Users;

public record Name
{
    public string Firstname { get; private set; }

    public string? Middlename { get; private set; }

    public string Surname { get; private set; }

    public string Fullname => GetFullName();

    public static Result<Name> Create(string firstName, string surname, string? middleName = null)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            return Result.Fail(NameErrors.FirstnameNullOrEmpty());
        }

        if (string.IsNullOrEmpty(surname))
        {
            return Result.Fail(NameErrors.SurnameNullOrEmpty());
        }

        if (string.IsNullOrEmpty(middleName))
        {
            return Result.Ok(new Name(firstName, surname));
        }

        return Result.Ok(new Name(firstName, middleName, surname));
    }

    private Name(string firstname, string surname)
    {
        Firstname = firstname;
        Surname = surname;
    }

    private Name(string firstname, string middlename, string surname)
    {
        Firstname = firstname;
        Surname = surname;
        Middlename = middlename;
    }

    private string GetFullName()
    {
        if (string.IsNullOrEmpty(Middlename))
        {
            return $"{Firstname} {Surname}";
        }
        return $"{Firstname} {Middlename} {Surname}";
    }
}