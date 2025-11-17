using Core.ActionHistoryContext.Entities;
using Core.ActionHistoryContext.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories.ActionHistoryRepositories;

/// <inheritdoc cref="IActionHistoryRepository"/>
public class ActionHistoryMongoRepository : IActionHistoryRepository
{
    private readonly IMongoDatabase _database;
    private const string CollectionPrefix = "ActionHistory_";

    public ActionHistoryMongoRepository(IMongoClient mongoClient, string databaseName)
    {
        _database = mongoClient.GetDatabase(databaseName);
    }

    /// <inheritdoc />
    public async Task LogAsync<T>(ActionHistoryDocument<T> document)
    {
        var collection = GetCollection<T>();
        await collection.InsertOneAsync(document);
    }

    /// <summary>
    /// Gets the MongoDB collection for the specified type T.
    /// </summary>
    private IMongoCollection<ActionHistoryDocument<T>> GetCollection<T>()
    {
        var collectionName = $"{CollectionPrefix}{typeof(T).Name}";
        return _database.GetCollection<ActionHistoryDocument<T>>(collectionName);
    }
}