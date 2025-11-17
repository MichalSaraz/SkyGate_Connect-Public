using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Enums;
using Core.SeatContext.Enums;

namespace Core.PassengerContext.JoinClasses.Entities;

/// <summary>
/// Represents the association between a passenger or item and a flight, including details
/// such as boarding sequence, flight class, and acceptance status.
/// </summary>
public class PassengerFlight
{
    /// <summary>
    /// Gets the passenger or item associated with this flight.
    /// </summary>
    public BasePassengerOrItem PassengerOrItem { get; }

    /// <summary>
    /// Gets the unique identifier of the passenger or item associated with this flight.
    /// </summary>
    public Guid PassengerOrItemId { get; private set; }

    /// <summary>
    /// Gets the flight associated with this passenger or item.
    /// </summary>
    public BaseFlight Flight { get; }

    /// <summary>
    /// Gets the unique identifier of the flight associated with this passenger or item.
    /// </summary>
    public Guid FlightId { get; private set; }

    /// <summary>
    /// Gets or sets the boarding sequence number for the passenger or item.
    /// This value is null when the acceptance status is <see cref="AcceptanceStatusEnum.NotAccepted"/> or
    /// <see cref="AcceptanceStatusEnum.NotTravelling"/>.
    /// </summary>
    public int? BoardingSequenceNumber { get; set; }

    /// <summary>
    /// Gets or sets the boarding zone for the passenger or item.
    /// This value is null when the acceptance status is <see cref="AcceptanceStatusEnum.NotAccepted"/> or
    /// <see cref="AcceptanceStatusEnum.NotTravelling"/>.
    /// </summary>
    public BoardingZoneEnum? BoardingZone { get; set; }

    /// <summary>
    /// Gets or sets the flight class for the passenger or item.
    /// </summary>
    public FlightClassEnum FlightClass { get; set; }

    /// <summary>
    /// Gets or sets the acceptance status of the passenger or item for the flight.
    /// Defaults to <see cref="AcceptanceStatusEnum.NotAccepted"/>.
    /// </summary>
    public AcceptanceStatusEnum AcceptanceStatus { get; set; } = AcceptanceStatusEnum.NotAccepted;

    /// <summary>
    /// Gets or sets the reason why the passenger or item is not traveling, if applicable.
    /// </summary>
    public NotTravellingReasonEnum? NotTravellingReason { get; set; }

    public PassengerFlight(Guid passengerOrItemId, Guid flightId, FlightClassEnum flightClass)
    {
        PassengerOrItemId = passengerOrItemId;
        FlightId = flightId;
        FlightClass = flightClass;
    }
}