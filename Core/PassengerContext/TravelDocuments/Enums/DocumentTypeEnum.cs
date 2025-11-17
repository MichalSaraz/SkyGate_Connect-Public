using System.ComponentModel;

namespace Core.PassengerContext.TravelDocuments.Enums;

/// <summary>
/// Represents the different types of travel documents that can be associated with a passenger.
/// </summary>
public enum DocumentTypeEnum
{
    /// <summary>
    /// Alien Passport - a travel document issued to non-citizens.
    /// </summary>
    [Description("Alien Passport")] AlienPassport,

    /// <summary>
    /// Emergency Passport - a temporary travel document issued in urgent situations.
    /// </summary>
    [Description("Emergency Passport")] EmergencyPassport,

    /// <summary>
    /// Normal Passport - a standard travel document issued to citizens.
    /// </summary>
    [Description("Normal Passport")] NormalPassport,

    /// <summary>
    /// National ID Card - an identification document that may be used for travel in certain regions.
    /// </summary>
    [Description("NationalIdCard")] NationalIdCard,

    /// <summary>
    /// Visa - an endorsement indicating permission to enter, leave, or stay in a country.
    /// </summary>
    [Description("Visa")] Visa,

    /// <summary>
    /// Residence Permit - a document allowing a foreign national to reside in a country.
    /// </summary>
    [Description("Residence Permit")] ResidencePermit
}