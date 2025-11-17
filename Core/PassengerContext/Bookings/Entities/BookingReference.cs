using System.ComponentModel.DataAnnotations;

namespace Core.PassengerContext.Bookings.Entities;

/// <summary>
/// Represents a booking reference, which includes the Passenger Name Record (PNR),
/// linked passengers, and the flight itinerary.
/// </summary>
public class BookingReference
{
    /// <summary>
    /// Gets or sets the Passenger Name Record (PNR), which is a unique 6-character alphanumeric code.
    /// </summary>
    /// <remarks>
    /// The PNR must match the regular expression "^[A-Z0-9]{6}$".
    /// </remarks>
    [Key]
    [RegularExpression("^[A-Z0-9]{6}$")]
    public string PNR { get; set; }

    /// <summary>
    /// Gets or sets the list of passengers linked to this booking.
    /// </summary>
    /// <remarks>
    /// This property is required and cannot be null.
    /// </remarks>
    [Required]
    public List<PassengerBookingDetails> LinkedPassengers { get; set; } = new();

    /// <summary>
    /// Gets or sets the flight itinerary for the booking, represented as a list of key-value pairs.
    /// </summary>
    /// <remarks>
    /// Each key-value pair contains a flight identifier (string) and the corresponding flight date and time (DateTime).
    /// </remarks>
    public List<KeyValuePair<string, DateTime>> FlightItinerary { get; set; } = new();
}