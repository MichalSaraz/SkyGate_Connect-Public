using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.BaggageRepositories.Logging;

/// <summary>
/// Centralized source-generated logging extensions for baggage repository operations.
/// EventId range 1–10 is reserved for <see cref="BaggageRepository"/>.
/// </summary>
public static partial class BaggageRepositoryLog
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information,
        Message = "Repository: Searching for baggage by tag: {TagNumber}")]
    public static partial void SearchingByTag(this ILogger logger, string tagNumber);

    [LoggerMessage(EventId = 2, Level = LogLevel.Warning,
        Message = "Repository: Baggage with tag {TagNumber} not found.")]
    public static partial void BaggageNotFound(this ILogger logger, string tagNumber);

    [LoggerMessage(EventId = 3, Level = LogLevel.Information,
        Message = "Repository: Baggage with tag {TagNumber} found: {BaggageId}")]
    public static partial void BaggageFound(this ILogger logger, string tagNumber, Guid baggageId);

    [LoggerMessage(EventId = 4, Level = LogLevel.Information,
        Message = "Repository: Searching for baggage by criteria. Tracked: {Tracked}")]
    public static partial void SearchingByCriteria(this ILogger logger, bool tracked);

    [LoggerMessage(EventId = 5, Level = LogLevel.Warning, Message = "Repository: Baggage by criteria not found.")]
    public static partial void CriteriaNotFound(this ILogger logger);

    [LoggerMessage(EventId = 6, Level = LogLevel.Information,
        Message = "Repository: Baggage by criteria found: {BaggageId}")]
    public static partial void CriteriaFound(this ILogger logger, Guid baggageId);

    [LoggerMessage(EventId = 7, Level = LogLevel.Information,
        Message = "Repository: Searching for all baggage by criteria. Tracked: {Tracked}")]
    public static partial void SearchingAllByCriteria(this ILogger logger, bool tracked);

    [LoggerMessage(EventId = 8, Level = LogLevel.Information,
        Message = "Repository: Found {Count} baggage items by criteria.")]
    public static partial void FoundItems(this ILogger logger, int count);

    [LoggerMessage(EventId = 9, Level = LogLevel.Information,
        Message = "Repository: Getting next sequence value: {SequenceName}")]
    public static partial void GettingNextSequence(this ILogger logger, string sequenceName);

    [LoggerMessage(EventId = 10, Level = LogLevel.Information,
        Message = "Repository: Next sequence value for {SequenceName}: {Value}")]
    public static partial void NextSequenceValue(this ILogger logger, string sequenceName, object value);
}