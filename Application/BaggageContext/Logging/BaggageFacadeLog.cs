using Microsoft.Extensions.Logging;

namespace Application.BaggageContext.Logging;

/// <summary>
/// Provides logging methods for baggage operations in the facade layer.
/// </summary>
internal static partial class BaggageFacadeLog
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information,
        Message = "Facade: Adding baggage for passenger {PassengerId} on flight {FlightId}. Count: {Count}")]
    public static partial void AddBaggageStarted(this ILogger logger, Guid passengerId, Guid flightId, int count);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information,
        Message = "Facade: Baggage added to database with ID: {BaggageId}")]
    public static partial void AddBaggageAdded(this ILogger logger, Guid baggageId);
    
    [LoggerMessage(EventId = 3, Level = LogLevel.Information,
        Message = "Facade: All baggage processed and saved: {Ids}")]
    public static partial void AddBaggageSuccess(this ILogger logger, string ids);

    [LoggerMessage(EventId = 4, Level = LogLevel.Information,
        Message = "Facade: Editing baggage for passenger {PassengerId} on flight {FlightId}. Count: {Count}")]
    public static partial void EditBaggageStarted(this ILogger logger, Guid passengerId, Guid flightId, int count);

    [LoggerMessage(EventId = 5, Level = LogLevel.Information,
        Message = "Facade: Baggage successfully edited: {Ids}")]
    public static partial void EditBaggageSuccess(this ILogger logger, string ids);

    [LoggerMessage(EventId = 6, Level = LogLevel.Information,
        Message = "Facade: Deleting baggage for passenger {PassengerId} on flight {FlightId}. Count: {Count}")]
    public static partial void DeleteBaggageStarted(this ILogger logger, Guid passengerId, Guid flightId, int count);

    [LoggerMessage(EventId = 7, Level = LogLevel.Information,
        Message = "Facade: Baggage successfully deleted: {Ids}")]
    public static partial void DeleteBaggageSuccess(this ILogger logger, string ids);
}