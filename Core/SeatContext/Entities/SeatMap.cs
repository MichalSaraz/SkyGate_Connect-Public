namespace Core.SeatContext.Entities;

/// <summary>
/// Represents a seat map, which includes an identifier and a list of flight class specifications.
/// </summary>
public class SeatMap
{
    /// <summary>
    /// Gets the unique identifier of the seat map.
    /// </summary>
    public string Id { get; private set; }

    /// <summary>
    /// Gets the list of flight class specifications associated with the seat map.
    /// </summary>
    public List<FlightClassSpecification> FlightClassesSpecification { get; private set; }

    public SeatMap(string id, List<FlightClassSpecification> flightClassesSpecification)
    {
        Id = id;
        FlightClassesSpecification = flightClassesSpecification;
    }
}