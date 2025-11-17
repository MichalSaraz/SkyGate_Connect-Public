using Core.BaggageContext.Entities;
using Core.PassengerContext.Bookings.Entities;
using Core.PassengerContext.Passengers.Enums;
using Core.PassengerContext.SpecialServiceRequests.Entities;

namespace Core.PassengerContext.Passengers.Entities;

/// <summary>
/// Represents a passenger, including details such as frequent flyer information, associated infant, baggage allowance,
/// priority boarding, and other related properties. Inherits from the <see cref="BasePassengerOrItem"/> class.
/// </summary>
public class Passenger : BasePassengerOrItem
{
    /// <summary>
    /// Gets or sets the frequent flyer card associated with the passenger.
    /// </summary>
    public FrequentFlyer FrequentFlyerCard { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the frequent flyer card.
    /// </summary>
    public Guid? FrequentFlyerCardId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated infant. The 'InfantId' property may have a value only if
    /// the associated 'Passenger' instance, which it refers to, has a value in the 'BookingDetails.Age' property
    /// greater than or equal to 18.
    /// </summary>
    public Guid? InfantId { get; set; }

    /// <summary>
    /// Gets or sets the infant associated with the passenger.
    /// </summary>
    public Infant Infant { get; set; }

    /// <summary>
    /// Gets or sets the baggage allowance for the passenger.
    /// </summary>
    public int BaggageAllowance { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the passenger has priority boarding.
    /// </summary>
    public bool PriorityBoarding { get; set; }

    /// <summary>
    /// Gets or sets the list of checked baggage items associated with the passenger.
    /// </summary>
    public List<Baggage> PassengerCheckedBags { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of special service requests associated with the passenger.
    /// </summary>
    public List<SpecialServiceRequest> SpecialServiceRequests { get; set; } = new();

    public Passenger(
        int baggageAllowance,
        bool priorityBoarding,
        string firstName,
        string lastName,
        PaxGenderEnum gender,
        Guid? bookingDetailsId,
        int? weight)
        : base(
            firstName,
            lastName,
            gender,
            bookingDetailsId,
            weight)
    {
        BaggageAllowance = baggageAllowance;
        PriorityBoarding = priorityBoarding;
    }
}