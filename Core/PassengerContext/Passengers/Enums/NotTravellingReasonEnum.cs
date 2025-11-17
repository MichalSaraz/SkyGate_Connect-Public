using System.ComponentModel;

namespace Core.PassengerContext.Passengers.Enums;

/// <summary>
/// Represents the reasons why a passenger is not traveling.
/// </summary>
public enum NotTravellingReasonEnum
{
    /// <summary>
    /// The passenger requested not to travel.
    /// </summary>
    [Description("Customer Request")] CustomerRequest,

    /// <summary>
    /// Offload reason related to airline staff.
    /// </summary>
    [Description("Airline Staff")] AirlineStaff,

    /// <summary>
    /// The passenger was denied boarding.
    /// </summary>
    [Description("Denied Boarding")] DeniedBoarding,

    /// <summary>
    /// The flight was canceled, and the passenger is not traveling.
    /// </summary>
    [Description("Flight Cancelled")] FlightCancelled,

    /// <summary>
    /// The passenger is not traveling due to a missed connection, typically caused by a delayed inbound flight.
    /// </summary>
    [Description("Flight Delayed")] MissedConnection,

    /// <summary>
    /// The passenger is not traveling due to medical reasons.
    /// </summary>
    [Description("Medical Reasons")] MedicalReasons,

    /// <summary>
    /// The passenger did not show up for the flight.
    /// </summary>
    [Description("No Show")] NoShow,

    /// <summary>
    /// The passenger is not traveling for other unspecified reasons.
    /// </summary>
    [Description("Other")] Other,

    /// <summary>
    /// The passenger did not meet regulatory requirements and cannot travel.
    /// </summary>
    [Description("Regulatory Requirement Not Met")]
    RegulatoryRequirementNotMet,

    /// <summary>
    /// The passenger is not traveling due to security reasons.
    /// </summary>
    [Description("Security Reasons")] SecurityReasons
}