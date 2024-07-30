namespace FitnessTracker.Domain.Users;

public record Name
{
    public string FirstName { get; private set; }
    public string SecondName { get; private set; }

    public Name(string firstName, string secondName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(firstName));
        }
        if (string.IsNullOrEmpty(secondName))
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(secondName));
        }
        FirstName = firstName;
        SecondName = secondName;
    }
}