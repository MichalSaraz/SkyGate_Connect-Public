using Core.FlightContext.ReferenceData.Entities;

namespace Core.FlightContext.Flights.Entities;

/// <summary>
/// Represents a scheduled flight, including its flight number, codeshare information, 
/// airline, destinations, and various timing details.
/// </summary>
public class ScheduledFlight
{
    /// <summary>
    /// Gets or sets the flight number of the scheduled flight.
    /// </summary>
    public string FlightNumber { get; set; }

    /// <summary>
    /// Gets or sets the codeshare flight numbers associated with the scheduled flight.
    /// </summary>
    public string[] Codeshare { get; set; }

    /// <summary>
    /// Gets or sets the airline operating the flight.
    /// </summary>
    public string Airline { get; set; }

    /// <summary>
    /// Gets or sets the departure destination of the flight.
    /// </summary>
    public Destination DestinationFrom { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the departure destination.
    /// </summary>
    public string DestinationFromId { get; set; }

    /// <summary>
    /// Gets or sets the arrival destination of the flight.
    /// </summary>
    public Destination DestinationTo { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the arrival destination.
    /// </summary>
    public string DestinationToId { get; set; }

    /// <summary>
    /// Gets or sets the flight duration for each flight within the week.
    /// </summary>
    public List<KeyValuePair<DayOfWeek, TimeSpan>> FlightDuration { get; set; } = new();

    /// <summary>
    /// Gets or sets the departure times in local time for each flight within the week.
    /// </summary>
    public List<KeyValuePair<DayOfWeek, TimeSpan>> DepartureTimesInLocalTime { get; set; } = new();

    /// <summary>
    /// Gets or sets the arrival times in local time for each flight within the week.
    /// </summary>
    public List<KeyValuePair<DayOfWeek, TimeSpan>> ArrivalTimesInLocalTime { get; set; } = new();

    /// <summary>
    /// Gets or sets the departure times in UTC for each flight within the week.
    /// </summary>
    public List<KeyValuePair<DayOfWeek, DateTimeOffset>> DepartureTimesInUTCTime { get; set; } = new();

    /// <summary>
    /// Gets or sets the arrival times in UTC for each flight within the week.
    /// </summary>
    public List<KeyValuePair<DayOfWeek, DateTimeOffset>> ArrivalTimesInUTCTime { get; set; } = new();
}