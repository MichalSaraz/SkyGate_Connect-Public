namespace Core.OperationResults;

/// <summary>
/// Represents a success result containing data of a specified type.
/// </summary>
/// <typeparam name="T">The type of the data contained in the success result.</typeparam>
public class SuccessResult<T> : Result
{
    /// <summary>
    /// Gets the data associated with the success result.
    /// </summary>
    public T Data { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuccessResult{T}"/> class with the specified data.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when the provided data is null.</exception>
    public SuccessResult(T data) : base(200)
    {
        Data = data ?? throw new ArgumentNullException(nameof(data), "Success result must contain valid data.");
    }
}

/// <summary>
/// Represents a success result containing a message or no additional data.
/// </summary>
public class SuccessResult : Result
{
    /// <summary>
    /// Gets the message associated with the success result.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuccessResult"/> class with no message.
    /// </summary>
    public SuccessResult() : base(200)
    {
        Message = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SuccessResult"/> class with the specified message.
    /// </summary>
    /// <param name="message">The message to include in the success result.</param>
    public SuccessResult(string message) : base(204)
    {
        Message = message;
    }
}