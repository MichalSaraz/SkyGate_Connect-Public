namespace Core.OperationResults;

/// <summary>
/// Represents a response with no data, containing only a status code and a message.
/// </summary>
public class NoDataResponse
{
    /// <summary>
    /// Gets the HTTP status code of the response.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// Gets the message associated with the response.
    /// </summary>
    public string Message { get; }

    public NoDataResponse(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}