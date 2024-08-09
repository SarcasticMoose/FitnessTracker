using FluentResults;

namespace FitnessTracker.Domain.Users;

public static class NameErrors
{
    public static Error FirstnameNullOrEmpty() => new($"Firstname cannot be null or empty");
    public static Error SurnameNullOrEmpty() => new($"Secondname cannot be null or empty");
}