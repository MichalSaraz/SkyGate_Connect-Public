using Application.BaggageContext.Commands;
using Core.OperationResults;

namespace Application.BaggageContext.Interfaces;

/// <summary>
/// Validation contract for baggage operations that enforces business rules
/// for a passenger and a flight and returns a <see cref="Result"/> describing success or failure.
/// </summary>
public interface IBaggageValidator
{
    /// <summary>
    /// Validates a batch of baggage creation commands for a specific passenger and flight.
    /// </summary>
    /// <param name="commands">A list of <see cref="CreateBaggageCommand"/> describing baggage items to create.</param>
    /// <param name="passengerId">The identifier of the passenger who will own the baggage items.</param>
    /// <param name="flightId">The identifier of the flight associated with the baggage items.</param>
    /// <returns>
    /// A <see cref="Task{Result}"/> that resolves to a <see cref="Result"/> describing validation outcome.
    /// On success, the result represents a successful validation. On failure, the result contains error details
    /// explaining why the validation failed (e.g., invalid weights, missing fields, or business-rule conflicts).
    /// </returns>
    Task<Result> ValidateAddBaggage(List<CreateBaggageCommand> commands, Guid passengerId, Guid flightId);

    /// <summary>
    /// Validates a batch of baggage edit commands for a specific passenger.
    /// </summary>
    /// <param name="commands">A list of <see cref="EditBaggageCommand"/> describing baggage items to edit.</param>
    /// <param name="passengerId">The identifier of the passenger who owns the baggage items.</param>
    /// <returns>
    /// A <see cref="Task{Result}"/> that resolves to a <see cref="Result"/> describing validation outcome.
    /// On success, the result represents a successful validation. On failure, the result contains error details
    /// explaining why the validation failed.
    /// </returns>
    Task<Result> ValidateEditBaggage(List<EditBaggageCommand> commands, Guid passengerId);

    /// <summary>
    /// Validates a batch of baggage deletion commands for a specific passenger.
    /// </summary>
    /// <param name="baggageIds">A list of baggage item identifiers to delete.</param>
    /// <param name="passengerId">The identifier of the passenger who owns the baggage items.</param>
    /// <returns>
    /// A <see cref="Task{Result}"/> that resolves to a <see cref="Result"/> describing validation outcome.
    /// On success, the result represents a successful validation. On failure, the result contains error details
    /// explaining why the validation failed.
    /// </returns>
    Task<Result> ValidateDeleteBaggage(List<Guid> baggageIds, Guid passengerId);
}