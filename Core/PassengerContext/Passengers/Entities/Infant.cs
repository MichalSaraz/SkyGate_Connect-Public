using Core.PassengerContext.Passengers.Enums;

namespace Core.PassengerContext.Passengers.Entities;

/// <summary>
/// Represents an infant passenger associated with an adult passenger.
/// Inherits from the <see cref="BasePassengerOrItem"/> class.
/// </summary>
public class Infant : BasePassengerOrItem
{
    /// <summary>
    /// Gets or sets the associated adult passenger.
    /// The associated passenger must have an age of 18 or higher for the infant to be associated.
    /// </summary>
    public Passenger AssociatedAdultPassenger { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated adult passenger.
    /// </summary>
    public Guid AssociatedAdultPassengerId { get; set; }

    public Infant(
        Guid associatedAdultPassengerId,
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
        AssociatedAdultPassengerId = associatedAdultPassengerId;
    }
}