using FluentValidation.Results;

namespace Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }


    public static void Requires(bool expected, string errorMessage)
    {
        if (!expected)
            throw new ValidationException(errorMessage);
    }

    public ValidationException(string message) : base(message)
    {

    }
    public IDictionary<string, string[]> Errors { get; }
}
