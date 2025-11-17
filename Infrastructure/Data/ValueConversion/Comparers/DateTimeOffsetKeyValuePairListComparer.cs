using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data.ValueConversion.Comparers;

/// <summary>
/// A custom value comparer for comparing lists of key-value pairs where the key is of type <see cref="DayOfWeek"/> 
/// and the value is of type <see cref="DateTimeOffset"/>.
/// </summary>
public class DateTimeOffsetKeyValuePairListComparer : ValueComparer<List<KeyValuePair<DayOfWeek, DateTimeOffset>>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeOffsetKeyValuePairListComparer"/> class.
    /// Configures the comparison logic for equality, hash code generation, and snapshot creation.
    /// </summary>
    public DateTimeOffsetKeyValuePairListComparer() : base(
        
        // Defines the equality comparison logic for two lists of key-value pairs.
        (c1, c2) => c1 != null && c2 != null && c1.Count == c2.Count &&
                    c1.Zip(c2, (a, b) => a.Key == b.Key && a.Value.Equals(b.Value)).All(result => result),
        
        // Defines the hash code generation logic for a list of key-value pairs.
        c => c != null
            ? c.Aggregate(0, (hash, pair) => HashCode
                .Combine(hash, pair.Key
                    .GetHashCode(), pair.Value
                    .GetHashCode()))
            : 0,
        
        // Defines the snapshot creation logic for a list of key-value pairs.
        c => c != null 
            ? c.Select(x => new KeyValuePair<DayOfWeek, DateTimeOffset>(x.Key, x.Value))
                .ToList() 
            : null)
    {
    }
}