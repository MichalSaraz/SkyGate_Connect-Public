using Application.BaggageContext.Commands;
using Core.BaggageContext.Entities;
using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Entities;

namespace Application.BaggageContext.Interfaces;

/// <summary>
/// Defines operations for creating and modifying baggage entities within the context of passengers and flights.
/// Implementations are responsible for mapping commands to domain entities, enforcing business rules,
/// and coordinating related side effects (e.g. history, validation, persistence).
/// </summary>
public interface IBaggageService
{
    /// <summary>
    /// Creates a new baggage entity based on the provided <see cref="CreateBaggageCommand"/>, and associates it
    /// with the specified passenger and flight.
    /// </summary>
    /// <param name="command">The creation command containing baggage details.</param>
    /// <param name="passenger">The <see cref="Passenger"/> to which the baggage belongs.</param>
    /// <param name="selectedFlight">The <see cref="Flight"/> in context for the baggage creation.</param>
    /// <returns>
    /// A <see cref="Task{Baggage}"/> that resolves to the newly created <see cref="Baggage"/> instance.
    /// </returns>
    Task<Baggage> CreateBaggage(CreateBaggageCommand command, Passenger passenger, Flight selectedFlight);

    /// <summary>
    /// Applies modifications described by <see cref="EditBaggageCommand"/> to an existing <see cref="Baggage"/>.
    /// </summary>
    /// <param name="command">The edit command containing modification details.</param>
    /// <param name="baggage">The target <see cref="Baggage"/> to modify.</param>
    /// <param name="flightId">The identifier of the flight context for the modification.</param>
    /// <returns>The modified <see cref="Baggage"/> instance.</returns>
    Baggage ModifyBaggage(EditBaggageCommand command, Baggage baggage, Guid flightId);
}