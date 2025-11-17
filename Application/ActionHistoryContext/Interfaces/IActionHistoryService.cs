using Core.ActionHistoryContext.Enums;

namespace Application.ActionHistoryContext.Interfaces;

public interface IActionHistoryService
{
    void CreateHistoryContext<T>(T originalValue, Guid passengerOrItemId, string? entityId = null);

    void CreateHistoryContexts<T>(IReadOnlyList<T> originalValues, IReadOnlyList<Guid> passengerOrItemIds,
        IReadOnlyList<string>? entityIds = null);

    void CreateHistoryContexts<T>(IReadOnlyList<T> originalValues, Guid passengerOrItemId,
        IReadOnlyList<string>? entityIds = null);

    Task SaveChangeToHistoryAsync<T>(T? newValue, ActionTypeEnum action, string type, Guid passengerOrItemId,
        string? entityId = null, T? originalValue = null)
        where T : class?;

    Task SaveChangesToHistoryAsync<T>(IReadOnlyList<T>? newValues, ActionTypeEnum action, string type,
        IReadOnlyList<Guid> passengerOrItemIds, List<string>? entityIds = null)
        where T : class?;

    Task SaveChangesToHistoryAsync<T>(IReadOnlyList<T>? newValues, ActionTypeEnum action, string type,
        Guid passengerOrItemId, IReadOnlyList<string>? entityIds = null)
        where T : class?;

}
