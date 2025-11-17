using Core.BaggageContext.Enums;
using Microsoft.Extensions.Logging;

namespace Application.BaggageContext.Logging;

/// <summary>
/// Contains logging methods for baggage-related operations in the service layer.
/// </summary>
internal static partial class BaggageServiceLog
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information,
        Message = "Service: Baggage created for passenger {PassengerId} on flight {FlightId}.")]
    public static partial void BaggageCreated(this ILogger logger, Guid passengerId, Guid flightId);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information,
        Message = "Service: Baggage assigned a tag number: {TagNumber}")]
    public static partial void BaggageTagAssigned(this ILogger logger, string tagNumber);

    [LoggerMessage(EventId = 3, Level = LogLevel.Information,
        Message = "Service: Generated new tag number: {Airline}{Number}")]
    public static partial void BaggageTagGenerated(this ILogger logger, string airline, int number);

    [LoggerMessage(EventId = 4, Level = LogLevel.Information,
        Message = "Service: FlightBaggage created: BaggageId={BaggageId}, FlightId={FlightId}, Type={Type}")]
    public static partial void FlightBaggageCreated(this ILogger logger, Guid baggageId, Guid flightId,
        BaggageTypeEnum type);

    [LoggerMessage(EventId = 5, Level = LogLevel.Information,
        Message = "Service: Added special bag type {Type} to baggage {BaggageId}.")]
    public static partial void SpecialBagAdded(this ILogger logger, SpecialBagEnum type, Guid baggageId);

    [LoggerMessage(EventId = 6, Level = LogLevel.Information,
        Message = "Service: Updated special bag for baggage {BaggageId}.")]
    public static partial void SpecialBagUpdated(this ILogger logger, Guid baggageId);

    [LoggerMessage(EventId = 7, Level = LogLevel.Information,
        Message = "Service: Removed special bag from baggage {BaggageId}.")]
    public static partial void SpecialBagRemoved(this ILogger logger, Guid baggageId);
}