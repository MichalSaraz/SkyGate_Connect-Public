using System.Diagnostics.CodeAnalysis;

namespace Core.OperationResults;

/// <summary>
/// Provides extension methods for the <see cref="Result"/> class.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Attempts to retrieve the data of a specified type from a <see cref="Result"/> object.
    /// </summary>
    /// <typeparam name="T">The type of the data to retrieve. Must be a non-nullable type.</typeparam>
    /// <param name="result">The <see cref="Result"/> object to extract the data from.</param>
    /// <param name="data">When this method returns, contains the data of type <typeparamref name="T"/> if found;
    /// otherwise, the default value of <typeparamref name="T"/>.</param>
    /// <returns><c>true</c> if the data of type <typeparamref name="T"/> was successfully retrieved; otherwise,
    /// <c>false</c>.</returns>
    public static bool TryGetData<T>(this Result result, [NotNullWhen(true)] out T data) where T : notnull
    {
        data = default;

        var dataProp = result.GetType().GetProperty("Data");

        var value = dataProp?.GetValue(result);
        if (value is T typed)
        {
            data = typed;
            return true;
        }

        return false;
    }
}