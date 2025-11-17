using Core.OperationResults;

namespace Application.Abstractions;

/// <summary>
/// Base class for handling query operations with common logic for scalar and collection requests.
/// </summary>
/// <typeparam name="TKey">The type of the key used to identify entities.</typeparam>
public class QueryBase<TKey>
{
    /// <summary>
    /// Handles a scalar request by invoking the provided repository method and returning a result.
    /// </summary>
    /// <typeparam name="T">The type of the data returned by the repository method.</typeparam>
    /// <param name="repositoryMethod">The asynchronous method to retrieve the data.</param>
    /// <param name="errorMessage">The error message to include in the result if the operation fails.</param>
    /// <returns>
    /// A <see cref="Task{Result}"/> representing the outcome of the operation. 
    /// Returns success if the data is valid, or failure with the provided error message.
    /// </returns>
    protected async Task<Result> _HandleScalarRequestAsync<T>(Func<Task<T>> repositoryMethod, string errorMessage)
    {
        var data = await repositoryMethod();

        if (data is bool boolResult)
        {
            return boolResult ? Result.Success() : Result.Failure(404, errorMessage);
        }

        if (data == null)
        {
            return Result.Failure(404, errorMessage);
        }

        return Result.Success(data);
    }

    /// <summary>
    /// Handles a collection request by invoking the provided repository method and returning a result.
    /// </summary>
    /// <typeparam name="TResult">The type of the collection returned by the repository method.</typeparam>
    /// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
    /// <param name="repositoryMethod">The asynchronous method to retrieve the collection.</param>
    /// <param name="errorMessage">The error message to include in the result if the operation fails.</param>
    /// <param name="expectedIds">Optional. A collection of expected IDs to validate against the retrieved data.</param>
    /// <param name="treatEmptyCollectionAsNotFound">Indicates whether an empty collection should be treated as
    /// a "not found" result.</param>
    /// <returns>
    /// A <see cref="Task{Result}"/> representing the outcome of the operation. 
    /// Returns success if the collection is valid or failure with the provided error message.
    /// </returns>
    protected async Task<Result> _HandleCollectionRequestAsync<TResult, TElement>(Func<Task<TResult>> repositoryMethod,
        string errorMessage, IEnumerable<TKey>? expectedIds = null, bool treatEmptyCollectionAsNotFound = true)
        where TResult : IEnumerable<TElement>
    {
        var data = await repositoryMethod();

        var resultList = data.ToList();
        if (!resultList.Any())
        {
            if (!treatEmptyCollectionAsNotFound)
            {
                return Result.Success(errorMessage);
            }

            return Result.Failure(404, errorMessage);
        }

        if (expectedIds != null)
        {
            var foundIds = ExtractIdsFromCollection(resultList);
            var missingIds = expectedIds.Except(foundIds).ToList();
            if (missingIds.Any())
            {
                var entityLabel = typeof(TElement).Name;
                return Result.Failure(404,
                    $"Following {entityLabel}s with Ids {string.Join(", ", missingIds)} were not found.");
            }
        }

        return Result.Success(data);
    }

    /// <summary>
    /// Extracts IDs from a collection of elements. This method should be overridden in derived classes.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="collection">The collection of elements to extract IDs from.</param>
    /// <returns>A set of IDs extracted from the collection.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the method is not overridden in a derived class.
    /// </exception>
    protected virtual HashSet<TKey> ExtractIdsFromCollection<T>(IEnumerable<T> collection)
    {
        throw new InvalidOperationException(
            $"Can't extract Ids of type {typeof(TKey).Name} from elements of type {typeof(T).Name}. Override in derived class.");
    }
}