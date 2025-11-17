using System.ComponentModel.DataAnnotations;
using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Entities;

namespace Core.PassengerContext.SpecialServiceRequests.Entities;

/// <summary>
/// Represents a Special Service Request (SSR) associated with a passenger and a flight.
/// </summary>
public class SpecialServiceRequest
{
    /// <summary>
    /// Composite key for <see cref="SpecialServiceRequest"/>. Provides value-based equality suitable for
    /// lookups, joins, and message passing.
    /// </summary>
    public readonly record struct Key(Guid PassengerId, Guid FlightId, string SSRCodeId);

    /// <summary>
    /// Gets the SSR code associated with this request.
    /// </summary>
    public SSRCode SSRCode { get; }

    /// <summary>
    /// Gets the unique identifier of the SSR code.
    /// </summary>
    public string SSRCodeId { get; private set; }

    /// <summary>
    /// Gets the passenger associated with this SSR.
    /// </summary>
    public Passenger Passenger { get; }

    /// <summary>
    /// Gets the unique identifier of the passenger associated with this SSR.
    /// </summary>
    public Guid PassengerId { get; private set; }

    /// <summary>
    /// Gets the flight associated with this SSR.
    /// </summary>
    public Flight Flight { get; }

    /// <summary>
    /// Gets the unique identifier of the flight associated with this SSR.
    /// </summary>
    public Guid FlightId { get; private set; }

    /// <summary>
    /// Gets the free text associated with this SSR, if applicable. Maximum length is 150 characters.
    /// </summary>
    [MaxLength(150)]
    public string FreeText { get; private set; }

    public SpecialServiceRequest(string sSRCodeId, Guid flightId, Guid passengerId, string freeText)
    {
        SSRCodeId = sSRCodeId;
        FlightId = flightId;
        PassengerId = passengerId;
        FreeText = freeText;
    }
}