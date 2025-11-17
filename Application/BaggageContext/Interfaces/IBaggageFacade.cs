using Application.BaggageContext.Commands;
using Core.BaggageContext.Dtos;
using Core.BaggageContext.Entities;
using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Entities;

namespace Application.BaggageContext.Interfaces;

/// <summary>
/// Defines the contract for baggage-related operations within the application layer.
/// </summary>
public interface IBaggageFacade
{
    /// <summary>
    /// Adds baggage for a specific passenger and flight based on the provided commands.
    /// </summary>
    /// <param name="passenger">The <see cref="Passenger"/> for whom the baggage is being added.</param>
    /// <param name="flight">The <see cref="Flight"/> associated with the baggage.</param>
    /// <param name="commands">A list of <see cref="CreateBaggageCommand"/> specifying the baggage details.</param>
    /// <param name="flightId">The unique identifier of the flight.</param>
    /// <param name="passengerId">The unique identifier of the passenger.</param>
    /// <returns>
    /// A list of <see cref="BaggageOverviewDto"/> representing the added baggage.
    /// </returns>
    Task<List<BaggageOverviewDto>> AddBaggageAsync(
        Passenger passenger, 
        Flight flight, 
        List<CreateBaggageCommand> commands, 
        Guid flightId, 
        Guid passengerId);

    /// <summary>
    /// Edits existing baggage for a specific passenger and flight based on the provided commands.
    /// </summary>
    /// <param name="commands">A list of <see cref="EditBaggageCommand"/> specifying the changes to be made.</param>
    /// <param name="baggageToEdit">A read-only list of <see cref="Baggage"/> to be edited.</param>
    /// <param name="flightId">The unique identifier of the flight.</param>
    /// <param name="passengerId">The unique identifier of the passenger.</param>
    /// <returns>
    /// A list of <see cref="BaggageOverviewDto"/> representing the updated baggage.
    /// </returns>
    Task<List<BaggageOverviewDto>> EditBaggageAsync(
        List<EditBaggageCommand> commands, 
        IReadOnlyList<Baggage> baggageToEdit, 
        Guid flightId, 
        Guid passengerId);

    /// <summary>
    /// Deletes baggage for a specific passenger and flight.
    /// </summary>
    /// <param name="baggage">A read-only list of <see cref="Baggage"/> to be deleted.</param>
    /// <param name="flightId">The unique identifier of the flight.</param>
    /// <param name="passengerId">The unique identifier of the passenger.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    Task DeleteBaggageAsync(
        IReadOnlyList<Baggage> baggage, 
        Guid flightId, 
        Guid passengerId);
}