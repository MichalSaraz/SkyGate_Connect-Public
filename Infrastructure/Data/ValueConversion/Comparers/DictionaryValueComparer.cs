using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data.ValueConversion.Comparers;

/// <summary>
/// A custom value comparer for comparing dictionaries with string keys and values of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the values in the dictionary.</typeparam>
public class DictionaryValueComparer<T> : ValueComparer<Dictionary<string, T>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DictionaryValueComparer{T}"/> class.
    /// Configures the comparison logic for equality, hash code generation, and snapshot creation.
    /// </summary>
    public DictionaryValueComparer()
        : base(
            // Defines the equality comparison logic for two dictionaries.
            (d1, d2) => CompareDictionaries(d1, d2),
            
            // Defines the hash code generation logic for a dictionary.
            d => GetDictionaryHashCode(d),
            
            // Defines the snapshot creation logic for a dictionary.
            d => d == null ? null : d.ToDictionary(x => x.Key, x => x.Value))
    {
    }

    /// <summary>
    /// Compares two dictionaries for equality.
    /// </summary>
    private static bool CompareDictionaries(Dictionary<string, T> a, Dictionary<string, T> b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a == null || b == null)
        {
            return false;
        }

        if (a.Count != b.Count)
        {
            return false;
        }

        var eq = EqualityComparer<T>.Default;
        foreach (var kvp in a)
        {
            if (!b.TryGetValue(kvp.Key, out var bv))
            {
                return false;
            }

            if (!eq.Equals(kvp.Value, bv))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Computes the hash code for a dictionary.
    /// </summary>
    private static int GetDictionaryHashCode(Dictionary<string, T> d)
    {
        if (d == null)
        {
            return 0;
        }

        int hash = 0;
        foreach (var kvp in d.OrderBy(k => k.Key))
        {
            var valueHash = kvp.Value != null 
                ? kvp.Value.GetHashCode() 
                : 0;
            
            hash = HashCode.Combine(hash, kvp.Key.GetHashCode(), valueHash);
        }

        return hash;
    }
}