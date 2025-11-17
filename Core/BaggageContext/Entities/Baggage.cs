using System.ComponentModel.DataAnnotations;
using Core.FlightContext.JoinClasses.Entities;
using Core.FlightContext.ReferenceData.Entities;
using Core.PassengerContext.Passengers.Entities;

namespace Core.BaggageContext.Entities;

/// <summary>
/// Represents a piece of baggage associated with a passenger and their journey.
/// </summary>
public class Baggage
{
    /// <summary>
    /// Gets the unique identifier of the baggage.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the passenger associated with the baggage.
    /// </summary>
    [Required]
    public Passenger Passenger { get; init; } 

    /// <summary>
    /// Gets the unique identifier of the passenger.
    /// </summary>
    public Guid PassengerId { get; private set; }

    /// <summary>
    /// Gets or sets the baggage tag information.
    /// </summary>
    public BaggageTag BaggageTag { get; set; }

    /// <summary>
    /// Gets or sets special bag information, if applicable.
    /// </summary>
    public SpecialBag SpecialBag { get; set; }

    /// <summary>
    /// Gets the final destination of the baggage.
    /// </summary>
    public Destination FinalDestination { get; init; }

    /// <summary>
    /// Gets the unique identifier of the destination.
    /// </summary>
    public string DestinationId { get; private set; }

    /// <summary>
    /// Gets or sets the weight of the baggage in kilograms.
    /// </summary>
    [Range(1, 32)]
    public int Weight { get; set; }

    /// <summary>
    /// Gets the list of flights associated with the baggage.
    /// </summary>
    public List<FlightBaggage> Flights { get; init; } = new();
    
    public Baggage(Guid passengerId, string destinationId, int weight)
    {
        Id = Guid.NewGuid();
        PassengerId = passengerId;
        DestinationId = destinationId;
        Weight = weight;
    }
}