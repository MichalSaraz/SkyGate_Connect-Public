using Core.PassengerContext.Bookings.Entities;
using Core.PassengerContext.Comments.Entities;
using Core.PassengerContext.JoinClasses.Entities;
using Core.PassengerContext.Passengers.Enums;
using Core.PassengerContext.TravelDocuments.Entities;
using Core.SeatContext.Entities;

namespace Core.PassengerContext.Passengers.Entities;

/// <summary>
/// Represents the base class for a passenger or item, including common properties such as identification, name, gender,
/// weight, and associated details like booking, travel documents, comments, assigned seats, and flights.
/// </summary>
public abstract class BasePassengerOrItem
{
    /// <summary>
    /// Gets the unique identifier of the passenger or item.
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Gets the first name of the passenger or item.
    /// </summary>
    public string FirstName { get; protected set; }

    /// <summary>
    /// Gets the last name of the passenger or item.
    /// </summary>
    public string LastName { get; protected set; }

    /// <summary>
    /// Gets the gender of the passenger or item.
    /// </summary>
    public PaxGenderEnum Gender { get; protected set; }

    /// <summary>
    /// Gets or sets the standardized weight of the passenger or item in kilograms. This value might be null only when
    /// the acceptance status is NotAccepted.
    /// </summary>
    public int? Weight { get; set; }

    /// <summary>
    /// Gets the booking details associated with the passenger or item.
    /// </summary>
    public PassengerBookingDetails BookingDetails { get; protected set; }

    /// <summary>
    /// Gets the unique identifier of the booking details associated with the passenger or item.
    /// </summary>
    public Guid? BookingDetailsId { get; protected set; }

    /// <summary>
    /// Gets or sets the list of travel documents associated with the passenger or item.
    /// </summary>
    public List<TravelDocument> TravelDocuments { get; set; }

    /// <summary>
    /// Gets or sets the list of comments associated with the passenger or item.
    /// </summary>
    public List<Comment> Comments { get; set; }

    /// <summary>
    /// Gets or sets the list of seats assigned to the passenger or item.
    /// </summary>
    public List<Seat> AssignedSeats { get; set; }

    /// <summary>
    /// Gets or sets the list of flights associated with the passenger or item.
    /// </summary>
    public List<PassengerFlight> Flights { get; set; } = new();

    protected BasePassengerOrItem(
        string firstName,
        string lastName,
        PaxGenderEnum gender,
        Guid? bookingDetailsId,
        int? weight)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        BookingDetailsId = bookingDetailsId;
        Weight = weight;
    }
}