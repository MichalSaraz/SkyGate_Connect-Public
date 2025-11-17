using System.ComponentModel.DataAnnotations;
using Core.FlightContext.ReferenceData.Entities;
using Core.PassengerContext.Bookings.Enums;
using Core.PassengerContext.Passengers.Entities;

namespace Core.PassengerContext.Bookings.Entities;

/// <summary>
/// Represents a frequent flyer associated with a passenger and an airline.
/// </summary>
public class FrequentFlyer
{
    /// <summary>
    /// Gets the unique identifier of the frequent flyer.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets or sets the frequent flyer number, which is a combination of the airline carrier code and the card number.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the provided frequent flyer number is less than 10 characters.
    /// </exception>
    public string FrequentFlyerNumber
    {
        get => $"{Airline.CarrierCode}{CardNumber}";
        set
        {
            if (value.Length < 10) throw new ArgumentException("Invalid FrequentFlyerNumber");

            AirlineId = value[..2];
            CardNumber = value[2..];
        }
    }

    /// <summary>
    /// Gets the passenger associated with this frequent flyer.
    /// </summary>
    public Passenger Passenger { get; }

    /// <summary>
    /// Gets the unique identifier of the passenger associated with this frequent flyer.
    /// </summary>
    public Guid PassengerId { get; private set; }

    /// <summary>
    /// Gets the airline associated with this frequent flyer.
    /// </summary>
    public Airline Airline { get; }

    /// <summary>
    /// Gets the unique identifier of the airline associated with this frequent flyer.
    /// </summary>
    public string AirlineId { get; private set; }

    /// <summary>
    /// Gets the card number of the frequent flyer.
    /// </summary>
    /// <remarks>
    /// The card number must be between 6 and 15 alphanumeric characters.
    /// </remarks>
    [Required]
    [RegularExpression("^[A-Z0-9]{6,15}$")]
    public string CardNumber { get; private set; }

    /// <summary>
    /// Gets the first name of the cardholder.
    /// </summary>
    [Required]
    public string CardholderFirstName { get; private set; }

    /// <summary>
    /// Gets the last name of the cardholder.
    /// </summary>
    [Required]
    public string CardholderLastName { get; private set; }

    /// <summary>
    /// Gets the tier level of the frequent flyer.
    /// </summary>
    [Required]
    public TierLevelEnum TierLever { get; private set; }

    /// <summary>
    /// Gets the number of miles available for the frequent flyer.
    /// </summary>
    public long MilesAvailable { get; private set; }
}