using Core.PassengerContext.Passengers.Enums;

namespace Core.PassengerContext.Passengers.Entities;

/// <summary>
/// Represents an extra seat associated with a passenger. Inherits from the <see cref="BasePassengerOrItem"/> class.
/// </summary>
public class ExtraSeat : BasePassengerOrItem
{
    public ExtraSeat(
        string firstName,
        string lastName,
        PaxGenderEnum gender,
        Guid? bookingDetailsId,
        int? weight = null) 
        : base(
            firstName,
            lastName, 
            gender, 
            bookingDetailsId, 
            weight)
    {
    }
}