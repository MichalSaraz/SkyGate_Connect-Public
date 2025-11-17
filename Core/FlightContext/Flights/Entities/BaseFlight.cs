using Core.FlightContext.JoinClasses.Entities;
using Core.FlightContext.ReferenceData.Entities;
using Core.PassengerContext.JoinClasses.Entities;

namespace Core.FlightContext.Flights.Entities;

/// <summary>
/// Represents the base class for a flight, including its details such as 
/// destinations, airline, departure and arrival times, and associated passengers and baggage.
/// </summary>
public abstract class BaseFlight
{
    /// <summary>
    /// Gets the unique identifier of the flight.
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Gets the departure destination of the flight.
    /// </summary>
    public Destination DestinationFrom { get; protected set; }

    /// <summary>
    /// Gets the identifier of the departure destination.
    /// </summary>
    public string DestinationFromId { get; protected set; }

    /// <summary>
    /// Gets the arrival destination of the flight.
    /// </summary>
    public Destination DestinationTo { get; protected set; }

    /// <summary>
    /// Gets the identifier of the arrival destination.
    /// </summary>
    public string DestinationToId { get; protected set; }

    /// <summary>
    /// Gets the airline operating the flight.
    /// </summary>
    public Airline Airline { get; protected set; }

    /// <summary>
    /// Gets the identifier of the airline operating the flight.
    /// </summary>
    public string AirlineId { get; protected set; }

    /// <summary>
    /// Gets or sets the departure date and time of the flight.
    /// </summary>
    public DateTime DepartureDateTime { get; set; }

    /// <summary>
    /// Gets or sets the UTC departure date and time of the flight.
    /// </summary>
    public DateTimeOffset UTCDepartureDateTime { get; set; }

    /// <summary>
    /// Gets or sets the arrival date and time of the flight, if available.
    /// </summary>
    public DateTime? ArrivalDateTime { get; set; }

    /// <summary>
    /// Gets or sets the UTC arrival date and time of the flight, if available.
    /// </summary>
    public DateTimeOffset? UTCArrivalDateTime { get; set; }

    /// <summary>
    /// Gets or sets the list of passengers booked on the flight.
    /// </summary>
    public List<PassengerFlight> ListOfBookedPassengers { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of baggage checked in for the flight.
    /// </summary>
    public List<FlightBaggage> ListOfCheckedBaggage { get; set; } = new();

    protected BaseFlight(
        DateTime departureDateTime, 
        DateTime? arrivalDateTime, 
        string destinationFromId,
        string destinationToId, 
        string airlineId)
    {
        Id = Guid.NewGuid();
        DepartureDateTime = departureDateTime;
        ArrivalDateTime = arrivalDateTime;
        DestinationFromId = destinationFromId;
        DestinationToId = destinationToId;
        AirlineId = airlineId;
    }
}