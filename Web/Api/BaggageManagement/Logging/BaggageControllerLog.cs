namespace Web.Api.BaggageManagement.Logging;

/// <summary>
/// Provides logging methods for baggage-related operations in the controller layer.
/// </summary>
internal static partial class BaggageControllerLog
{
    [LoggerMessage(EventId = 10, Level = LogLevel.Information,
        Message =
            "Controller: Request received: Add baggage for passenger {PassengerId} on flight {FlightId}. Model count: {Count}")]
    public static partial void AddBaggageRequestReceived(this ILogger logger, Guid passengerId, Guid flightId,
        int count);

    [LoggerMessage(EventId = 13, Level = LogLevel.Information,
        Message =
            "Controller: Request received: Edit baggage for passenger {PassengerId} on flight {FlightId}. Model count: {Count}")]
    public static partial void EditBaggageRequestReceived(this ILogger logger, Guid passengerId, Guid flightId,
        int count);

    [LoggerMessage(EventId = 16, Level = LogLevel.Information,
        Message =
            "Controller: Request received: Delete baggage for passenger {PassengerId} on flight {FlightId}. Count: {Count}")]
    public static partial void DeleteBaggageRequestReceived(this ILogger logger, Guid passengerId, Guid flightId,
        int count);
}