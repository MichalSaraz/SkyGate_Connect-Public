namespace Web.Errors;

/// <summary>
/// Represents an API exception that includes additional details about the error. Inherits from
/// <see cref="ApiResponse"/>.
/// </summary>
public class ApiException : ApiResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class.
    /// </summary>
    /// <param name="statusCode">The HTTP status code associated with the exception.</param>
    /// <param name="message">An optional message describing the error.</param>
    /// <param name="details">Optional additional details about the error.</param>
    public ApiException(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
    {
        Details = details;
    }

    /// <summary>
    /// Gets or sets additional details about the error.
    /// </summary>
    public string? Details { get; set; }
}