namespace Core.FlightContext.Flights.Entities;

/// <summary>
/// Represents a flight with a specific flight number, inheriting from the <see cref="BaseFlight"/> class.
/// </summary>
public class OtherFlight : BaseFlight
{
    /// <summary>
    /// Gets the flight number of the flight.
    /// </summary>
    public string FlightNumber { get; private set; }

    public OtherFlight( 
        string flightNumber,
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
        FlightNumber = flightNumber;
    }
}