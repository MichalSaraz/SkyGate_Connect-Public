using System.ComponentModel.DataAnnotations;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Enums;
using Core.SeatContext.Enums;

namespace Core.PassengerContext.Bookings.Entities;

/// <summary>
/// Represents the details of a passenger's booking, including personal information,
/// booking references, and additional booking-related data.
/// </summary>
public class PassengerBookingDetails
{
    /// <summary>
    /// Gets the unique identifier of the passenger booking.
    /// </summary>
    [Required]
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the first name of the passenger.
    /// </summary>
    [Required]
    public string FirstName { get; private set; }

    /// <summary>
    /// Gets the last name of the passenger.
    /// </summary>
    [Required]
    public string LastName { get; private set; }

    /// <summary>
    /// Gets the gender of the passenger.
    /// </summary>
    [Required]
    public PaxGenderEnum Gender { get; private set; }

    /// <summary>
    /// Gets the booking reference associated with the passenger.
    /// </summary>
    [Required]
    public BookingReference PNR { get; }

    /// <summary>
    /// Gets the unique identifier of the booking reference.
    /// </summary>
    public string PNRId { get; private set; }

    /// <summary>
    /// Gets or sets the age of the passenger, if available.
    /// </summary>
    public int? Age { get; set; }

    /// <summary>
    /// Gets or sets the baggage allowance for the passenger.
    /// </summary>
    public int BaggageAllowance { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the passenger has priority boarding.
    /// </summary>
    public bool PriorityBoarding { get; set; }

    /// <summary>
    /// Gets or sets the frequent flyer card number of the passenger, if applicable.
    /// </summary>
    public string FrequentFlyerCardNumber { get; set; }

    /// <summary>
    /// Gets the passenger or item associated with this booking.
    /// </summary>
    public BasePassengerOrItem PassengerOrItem { get; }

    /// <summary>
    /// Gets or sets the unique identifier of the passenger or item associated with this booking.
    /// </summary>
    public Guid? PassengerOrItemId { get; set; }

    /// <summary>
    /// Gets the associated passenger booking details, like infant or adult companion, if applicable.
    /// </summary>
    public PassengerBookingDetails AssociatedPassengerBookingDetails { get; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated passenger booking details, if applicable.
    /// </summary>
    public Guid? AssociatedPassengerBookingDetailsId { get; set; }

    /// <summary>
    /// Gets the dictionary of booked flight classes, where the key is the flight identifier
    /// and the value is the flight class.
    /// </summary>
    public Dictionary<string, FlightClassEnum> BookedClass { get; private set; } = new();

    /// <summary>
    /// Gets or sets the dictionary of reserved seats, where the key is the flight identifier
    /// and the value is the seat number.
    /// </summary>
    public Dictionary<string, string> ReservedSeats { get; set; } = new();

    /// <summary>
    /// Gets or sets the dictionary of booked special service requests (SSR), where the key is the flight identifier
    /// and the value is a list of SSR codes.
    /// </summary>
    public Dictionary<string, List<string>> BookedSSR { get; set; } = new();

    public PassengerBookingDetails()
    {
    }

    public PassengerBookingDetails(string firstName, string lastName, PaxGenderEnum gender, string pNRId)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PNRId = pNRId;
    }
}