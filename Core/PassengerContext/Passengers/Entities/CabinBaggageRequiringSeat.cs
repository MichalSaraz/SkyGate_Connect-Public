using Core.PassengerContext.Passengers.Enums;

namespace Core.PassengerContext.Passengers.Entities;

/// <summary>
/// Represents a cabin baggage item that requires a seat assignment. Inherits from the <see cref="BasePassengerOrItem"/>
/// class.
/// </summary>
public class CabinBaggageRequiringSeat : BasePassengerOrItem
{
    public CabinBaggageRequiringSeat(
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
    }
}