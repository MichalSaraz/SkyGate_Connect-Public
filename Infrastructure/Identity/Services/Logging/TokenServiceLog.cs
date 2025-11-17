using Microsoft.Extensions.Logging;

namespace Infrastructure.Identity.Services.Logging;

/// <summary>
/// Provides logging methods for token service operations.
/// </summary>
internal static partial class TokenServiceLog
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information,
        Message = "Creating JWT token for user '{userName}' with role '{role}'.")]
    public static partial void TokenCreating(this ILogger logger, string userName, string role);

    [LoggerMessage(EventId = 2, Level = LogLevel.Warning, Message = "Token signing key is missing or empty.")]
    public static partial void TokenKeyMissing(this ILogger logger);

    [LoggerMessage(EventId = 3, Level = LogLevel.Debug,
        Message = "Token issued by '{issuer}', expires '{expiresUtc:O}'.")]
    public static partial void TokenIssued(this ILogger logger, string? issuer, DateTime expiresUtc);
}