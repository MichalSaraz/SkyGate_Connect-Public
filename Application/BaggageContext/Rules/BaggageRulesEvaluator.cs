using Application.BaggageContext.Commands;
using Application.BaggageContext.Interfaces;
using Core.PassengerContext.Passengers.Entities;

namespace Application.BaggageContext.Rules;

/// <inheritdoc cref="IBaggageRulesEvaluator"/>
public class BaggageRulesEvaluator : IBaggageRulesEvaluator
{
    /// <inheritdoc/>
    public bool HasMatchingFinalDestination(List<CreateBaggageCommand> commands, Passenger passenger)
    {
        if (commands.Count == 0 || passenger.Flights == null)
        {
            return false;
        }

        var normalizedDestination = commands.First().FinalDestination?.Trim().ToUpperInvariant();
        if (normalizedDestination == null)
        {
            return false;
        }

        bool allSame = commands.All(c => c.FinalDestination.Trim().ToUpperInvariant() == normalizedDestination);
        bool matchesFlight = passenger.Flights.Any(f =>
            f.Flight?.DestinationToId?.Trim().ToUpperInvariant() == normalizedDestination);

        return allSame && matchesFlight;
    }
}