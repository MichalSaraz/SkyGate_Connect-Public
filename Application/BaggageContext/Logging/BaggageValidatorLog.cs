using Microsoft.Extensions.Logging;

namespace Application.BaggageContext.Logging;

/// <summary>
/// Provides logging methods for baggage validation operations.
/// </summary>
internal static partial class BaggageValidatorLog
{
[LoggerMessage(EventId = 1, Level = LogLevel.Warning, Message = "Validator: no data provided.")]
public static partial void AddNoDataProvided(this ILogger logger);

[LoggerMessage(EventId = 2, Level = LogLevel.Warning,
    Message = "Validator: missing TagNumber for manual tag.")]
public static partial void AddMissingTagNumber(this ILogger logger);

[LoggerMessage(EventId = 5, Level = LogLevel.Warning,
    Message = "Validator: passenger {PassengerId} not checked in.")]
public static partial void AddPassengerNotCheckedIn(this ILogger logger, Guid passengerId);

[LoggerMessage(EventId = 6, Level = LogLevel.Warning,
    Message = "Validator: flight {FlightId} not open for edits.")]
public static partial void AddFlightNotOpenForEdits(this ILogger logger, Guid flightId);

[LoggerMessage(EventId = 8, Level = LogLevel.Warning, Message = "Validator: final destination mismatch.")]
public static partial void AddFinalDestinationMismatch(this ILogger logger);

[LoggerMessage(EventId = 9, Level = LogLevel.Warning, Message = "Validator: no data provided.")]
public static partial void EditNoDataProvided(this ILogger logger);
}