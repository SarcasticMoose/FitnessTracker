using System.Runtime.CompilerServices;
using FluentResults;

namespace SharedKernel.Errors;

// ReSharper disable once EntityNameCapturedOnly.Local
public class NullOrEmptyError : Error
{
    private readonly string? _argument;

    public NullOrEmptyError(string? argument)
    {
        _argument = argument;
        CausedBy($"Argument {nameof(argument)} was null or empty");
    }
}