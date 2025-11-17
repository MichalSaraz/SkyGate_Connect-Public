using Core.ActionHistoryContext.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.ActionHistoryContext.Entities;

/// <summary>
/// Represents a document that tracks the history of actions performed on an entity.
/// </summary>
/// <typeparam name="T">The type of the entity being tracked.</typeparam>
public class ActionHistoryDocument<T>
{
    /// <summary>
    /// Gets or sets the unique identifier of the document.
    /// </summary>
    [BsonId]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the passenger or item associated with the action.
    /// </summary>
    [BsonElement("passengerOrItemId")]
    [BsonRequired]
    public Guid PassengerOrItemId { get; set; }

    /// <summary>
    /// Gets or sets the type of the entity being tracked.
    /// </summary>
    [BsonElement("entityType")]
    [BsonRequired]
    public string EntityType { get; set; }

    /// <summary>
    /// Gets or sets the type of action performed on the entity.
    /// </summary>
    [BsonElement("action")]
    [BsonRepresentation(BsonType.String)]
    [BsonRequired]
    public ActionTypeEnum Action { get; set; }

    /// <summary>
    /// Gets or sets the serialized representation of the entity's old value before the action.
    /// </summary>
    [BsonElement("oldValue")]
    public string SerializedOldValue { get; set; }

    /// <summary>
    /// Gets or sets the serialized representation of the entity's new value after the action.
    /// </summary>
    [BsonElement("newValue")]
    [BsonRequired]
    public string SerializedNewValue { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of when the action was performed.
    /// </summary>
    [BsonElement("timestamp")]
    [BsonRequired]
    public DateTimeOffset Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who performed the action.
    /// </summary>
    [BsonElement("userName")]
    [BsonRequired]
    public string UserName { get; set; }
}