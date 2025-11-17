namespace Web.Api.AccountManagement.Logging;

/// <summary>
/// Provides logging methods for account management operations in the AccountController.
/// </summary>
internal static partial class AccountControllerLog
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Login attempt for user '{userName}'.")]
    public static partial void LoginAttempt(this ILogger logger, string userName);

    [LoggerMessage(EventId = 2, Level = LogLevel.Warning, Message = "Login failed for user '{userName}'.")]
    public static partial void LoginFailed(this ILogger logger, string userName);

    [LoggerMessage(EventId = 3, Level = LogLevel.Information, Message = "Login succeeded for user '{userName}'.")]
    public static partial void LoginSucceeded(this ILogger logger, string userName);

    [LoggerMessage(EventId = 4, Level = LogLevel.Information,
        Message = "Register attempt for user '{userName}' at station '{station}' with role '{role}'.")]
    public static partial void RegisterAttempt(this ILogger logger, string userName, string? station, string role);

    [LoggerMessage(EventId = 5, Level = LogLevel.Warning,
        Message = "Register failed: username '{userName}' already exists.")]
    public static partial void RegisterExists(this ILogger logger, string userName);

    [LoggerMessage(EventId = 6, Level = LogLevel.Information, Message = "Register succeeded for user '{userName}'.")]
    public static partial void RegisterSucceeded(this ILogger logger, string userName);

    [LoggerMessage(EventId = 7, Level = LogLevel.Debug, Message = "Checking if username '{userName}' exists.")]
    public static partial void CheckUserNameExists(this ILogger logger, string userName);
}