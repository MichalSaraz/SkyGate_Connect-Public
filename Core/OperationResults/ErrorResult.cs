namespace Core.OperationResults;

/// <summary>
/// Represents an error result, which includes an error message and a status code.
/// </summary>
public class ErrorResult : Result
{
    /// <summary>
    /// Gets the error message associated with the result.
    /// </summary>
    public string ErrorMessage { get; }

    public ErrorResult(int statusCode, string errorMessage) : base(statusCode)
    {
        ErrorMessage = errorMessage ?? string.Empty;
    }
}