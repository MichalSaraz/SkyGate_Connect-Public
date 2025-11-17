using Application.ActionHistoryContext.Interfaces;
using Core.ActionHistoryContext.Entities;
using Core.ActionHistoryContext.Enums;
using Core.ActionHistoryContext.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Application.ActionHistoryContext.Services;

public class ActionHistoryService : IActionHistoryService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IActionHistoryRepository _historyRepository;
    private readonly List<IActionHistoryScope> _contexts = new();
    private IActionHistoryScope? _context;
    
    public ActionHistoryService(IHttpContextAccessor httpContextAccessor, IActionHistoryRepository historyRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _historyRepository = historyRepository;
    }

    public void CreateHistoryContext<T>(T originalValue, Guid passengerOrItemId, string? entityId = null)
    {
        var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "System";

        _context = new ActionHistoryScope<T>(originalValue, userName, passengerOrItemId, entityId);
        _contexts.Add(_context);
    }

    public void CreateHistoryContexts<T>(
        IReadOnlyList<T> originalValues,
        IReadOnlyList<Guid> passengerOrItemIds,
        IReadOnlyList<string>? entityIds = null)
    {
        if (originalValues.Count != passengerOrItemIds.Count)
        {
            throw new ArgumentException("Count of originalValues and entityIds must match");
        }

        CreateHistoryContextsInternal(originalValues, i => passengerOrItemIds[i], entityIds);
    }

    public void CreateHistoryContexts<T>(
        IReadOnlyList<T> originalValues, 
        Guid passengerOrItemId,
        IReadOnlyList<string>? entityIds = null)
    {
        CreateHistoryContextsInternal(originalValues, _ => passengerOrItemId, entityIds);
    }

    public async Task SaveChangeToHistoryAsync<T>(
        T? newValue, 
        ActionTypeEnum action, 
        string type,
        Guid passengerOrItemId,
        string? entityId = null,
        T? originalValue = null) where T : class?
    {
        if (action != ActionTypeEnum.Created && _context == null && originalValue == null)
        {
            throw new InvalidOperationException("No history context found. Please create one before saving changes.");
        }
        if (newValue == null && action != ActionTypeEnum.Deleted)
        {
            throw new InvalidOperationException("newValue cannot be null except for Delete action");
        }

        var doc = _CreateHistoryDocument(newValue, action, type, passengerOrItemId, entityId, originalValue);
        await _historyRepository.LogAsync(doc);
    }

    public async Task SaveChangesToHistoryAsync<T>(IReadOnlyList<T>? newValues,
        ActionTypeEnum action,
        string type,
        IReadOnlyList<Guid> passengerOrItemIds,
        List<string>? entityIds = null) where T : class?
    {
        if (newValues != null && passengerOrItemIds.Count != newValues.Count)
        {
            throw new InvalidOperationException("Count of entityIds must match count of newValues.");
        }

        await _SaveChangesToHistoryInternalAsync(newValues, action, type, i => passengerOrItemIds[i], entityIds);
    }

    public async Task SaveChangesToHistoryAsync<T>(
        IReadOnlyList<T>? newValues,
        ActionTypeEnum action,
        string type,
        Guid passengerOrItemId,
        IReadOnlyList<string>? entityIds = null) where T : class?
    {
        await _SaveChangesToHistoryInternalAsync(newValues, action, type, _ => passengerOrItemId, entityIds);
    }
    
    private void CreateHistoryContextsInternal<T>(
        IReadOnlyList<T> originalValues,
        Func<int, Guid> getPassengerOrItemId,
        IReadOnlyList<string>? entityIds = null)
    {
        for (int i = 0; i < originalValues.Count; i++)
        {
            CreateHistoryContext(
                originalValues[i],
                getPassengerOrItemId(i),
                entityIds != null && entityIds.Count == originalValues.Count ? entityIds[i] : null);
        }
    }

    private async Task _SaveChangesToHistoryInternalAsync<T>(
        IReadOnlyList<T>? newValues, 
        ActionTypeEnum action,
        string type, 
        Func<int, Guid> getPassengerOrItemId, 
        IReadOnlyList<string>? entityIds = null) where T : class?
    {
        if (action == ActionTypeEnum.Deleted)
        {
            if (!_contexts.Any())
            {
                throw new InvalidOperationException("No history contexts found for Delete operation.");
            }

            var contextsToProcess = entityIds != null
                ? _contexts.Where(c => entityIds.Contains((c as ActionHistoryScope<T>)?.EntityId))
                    .Cast<ActionHistoryScope<T>>()
                : _contexts.Cast<ActionHistoryScope<T>>();

            var tasks = contextsToProcess.Select((context, i) =>
                SaveChangeToHistoryAsync(null, action, type, getPassengerOrItemId(i), 
                    context?.EntityId, context?.OriginalValue));

            await Task.WhenAll(tasks);
            
            return;
        }

        if (newValues == null)
        {
            throw new InvalidOperationException($"newValues cannot be null for {action} operation.");
        }

        var saveTasks = Enumerable.Range(0, newValues.Count).Select(i =>
            SaveChangeToHistoryAsync(newValues[i], action, type, getPassengerOrItemId(i),
                originalValue: i < _contexts.Count ? (_contexts[i] as ActionHistoryScope<T>)?.OriginalValue : null));

        await Task.WhenAll(saveTasks);
    }
    
    private ActionHistoryDocument<T> _CreateHistoryDocument<T>(
        T? newValue, 
        ActionTypeEnum action, 
        string type,
        Guid passengerOrItemId, 
        string? entityId = null, 
        T? originalValue = null) where T : class?
    {
        var context = entityId != null
            ? _contexts.FirstOrDefault(c => (c as ActionHistoryScope<T>)?.EntityId == entityId) as
                ActionHistoryScope<T>
            : _context as ActionHistoryScope<T>;

        return new ActionHistoryDocument<T>
        {
            Id = Guid.NewGuid(),
            PassengerOrItemId = passengerOrItemId,
            EntityType = type,
            Action = action,
            SerializedOldValue = action == ActionTypeEnum.Created 
                ? null 
                : JsonConvert.SerializeObject(originalValue ?? context?.OriginalValue,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }),
            SerializedNewValue = action == ActionTypeEnum.Deleted 
                ? null 
                : JsonConvert.SerializeObject(newValue,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }),
            Timestamp = DateTimeOffset.UtcNow,
            UserName = _context?.UserName ?? _httpContextAccessor.HttpContext?.User.Identity?.Name ?? "System"
        };
    }
}