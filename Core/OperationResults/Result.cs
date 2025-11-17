namespace Core.OperationResults;

/// <summary>
/// Represents the base class for results, providing functionality for success and failure responses.
/// </summary>
public abstract class Result
{
    /// <summary>
    /// Gets the HTTP status code associated with the result.
    /// </summary>
    private int StatusCode { get; }

    /// <summary>
    /// Gets the response where no data is returned. It contains only the status code and message.
    /// </summary>
    public NoDataResponse NoDataResponse { get; private set; }

    protected Result(int statusCode)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Sets the <see cref="NoDataResponse"/> for the result.
    /// </summary>
    private void SetNoDataResponse(NoDataResponse response)
    {
        NoDataResponse = response;
    }

    /// <summary>
    /// Creates a success result with the specified data.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    /// <param name="data">The data to include in the success result.</param>
    /// <returns>A new instance of <see cref="SuccessResult{T}"/>.</returns>
    public static SuccessResult<T> Success<T>(T data)
    {
        return new SuccessResult<T>(data);
    }

    /// <summary>
    /// Creates a success result with the specified message.
    /// </summary>
    /// <param name="message">The message to include in the success result.</param>
    /// <returns>A new instance of <see cref="SuccessResult"/>.</returns>
    public static SuccessResult Success(string message)
    {
        var noDataResponse = new NoDataResponse(200, message);
        var successResult = new SuccessResult(message);
        successResult.SetNoDataResponse(noDataResponse);
        return successResult;
    }

    /// <summary>
    /// Creates a success result with no additional data or message.
    /// </summary>
    /// <returns>A new instance of <see cref="SuccessResult"/>.</returns>
    public static SuccessResult Success()
    {
        return new SuccessResult();
    }

    /// <summary>
    /// Creates an error result with the specified status code and error message.
    /// </summary>
    /// <param name="statusCode">The HTTP status code associated with the error.</param>
    /// <param name="errorMessage">The error message describing the error.</param>
    /// <returns>A new instance of <see cref="ErrorResult"/>.</returns>
    public static ErrorResult Failure(int statusCode, string errorMessage)
    {
        var noDataResponse = new NoDataResponse(statusCode, errorMessage);
        var errorResult = new ErrorResult(statusCode, errorMessage);
        errorResult.SetNoDataResponse(noDataResponse);
        return errorResult;
    }
}