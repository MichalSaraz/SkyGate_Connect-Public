using Core.FlightContext.Flights.Enums;
using Core.FlightContext.JoinClasses.Entities;
using Core.FlightContext.ReferenceData.Entities;
using Core.PassengerContext.SpecialServiceRequests.Entities;
using Core.SeatContext.Entities;

namespace Core.FlightContext.Flights.Entities;

/// <summary>
/// Represents a flight, including its scheduled flight, aircraft, seating arrangements,
/// boarding and flight statuses, and associated comments and special service requests.
/// </summary>
public class Flight : BaseFlight
{
    /// <summary>
    /// Gets the scheduled flight associated with this flight.
    /// </summary>
    public ScheduledFlight ScheduledFlight { get; }

    /// <summary>
    /// Gets the unique identifier of the scheduled flight.
    /// </summary>
    public string ScheduledFlightId { get; private set; }

    /// <summary>
    /// Gets the aircraft assigned to this flight.
    /// </summary>
    public Aircraft Aircraft { get; }

    /// <summary>
    /// Gets or sets the unique identifier of the aircraft.
    /// </summary>
    public string AircraftId { get; set; }

    /// <summary>
    /// Gets or sets the row number behind which a divider is placed, if any.
    /// </summary>
    public int? DividerPlacedBehindRow { get; set; }

    /// <summary>
    /// Gets or sets the boarding status of the flight.
    /// </summary>
    public BoardingStatusEnum BoardingStatus { get; set; } = BoardingStatusEnum.Closed;

    /// <summary>
    /// Gets or sets the current status of the flight.
    /// </summary>
    public FlightStatusEnum FlightStatus { get; set; } = FlightStatusEnum.Open;

    /// <summary>
    /// Gets the list of seats available on the flight.
    /// </summary>
    public List<Seat> Seats { get; private set; } = new();

    /// <summary>
    /// Gets the list of comments associated with the flight.
    /// </summary>
    public List<FlightComment> Comments { get; private set; } = new();

    /// <summary>
    /// Gets the list of special service requests associated with the flight.
    /// </summary>
    public List<SpecialServiceRequest> SSRList { get; private set; } = new();

    public Flight(
        string scheduledFlightId, 
        DateTime departureDateTime, 
        DateTime? arrivalDateTime,
        string destinationFromId, 
        string destinationToId, 
        string airlineId) 
        : base(
            departureDateTime, 
            arrivalDateTime,
            destinationFromId,
            destinationToId,
            airlineId)
    {
        ScheduledFlightId = scheduledFlightId;
    }
}