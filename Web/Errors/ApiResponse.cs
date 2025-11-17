namespace Web.Errors;

/// <summary>
/// Represents a standard API response with a status code and an optional message.
/// </summary>
public class ApiResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResponse"/> class with the specified status code
    /// and optional message.
    /// </summary>
    /// <remarks>If no message is provided, a default message based on the status code will be used.</remarks>
    public ApiResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }
 
    public int StatusCode { get; set; }
        
    public string? Message { get; set; }

    /// <summary>
    /// Gets the default error message for a given status code.
    /// </summary>
    private static string? GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "A bad request, you have made",
            401 => "Authorized, you are not",
            404 => "Resource found, it was not",
            409 => "Conflict, there is",
            500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
            _ => null
        };
    }
}