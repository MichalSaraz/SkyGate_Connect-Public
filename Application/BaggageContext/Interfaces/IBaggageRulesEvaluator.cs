using Application.BaggageContext.Commands;
using Core.PassengerContext.Passengers.Entities;

namespace Application.BaggageContext.Interfaces;

/// <summary>
/// Evaluates baggage-related rules.
/// </summary>
public interface IBaggageRulesEvaluator
{
    /// <summary>
    /// Checks whether all <see cref="CreateBaggageCommand"/> have the same final destination as the given
    /// <see cref="Passenger"/>.
    /// </summary>
    /// <param name="commands">Baggage creation commands to check.</param>
    /// <param name="passenger">Reference passenger.</param>
    /// <returns><see cref="bool"/>: true if all destinations match; otherwise false.</returns>
    bool HasMatchingFinalDestination(List<CreateBaggageCommand> commands, Passenger passenger);
}