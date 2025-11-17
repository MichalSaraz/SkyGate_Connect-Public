using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data.ValueConversion.Comparers;

/// <summary>
/// A custom value comparer for comparing lists of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class ListValueComparer<T> : ValueComparer<List<T>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListValueComparer{T}"/> class.
    /// Configures the comparison logic for equality, hash code generation, and snapshot creation.
    /// </summary>
    public ListValueComparer()
        : base(
            // Defines the equality comparison logic for two lists.
            (c1, c2) => CompareLists(c1, c2),
            
            // Defines the hash code generation logic for a list.
            c => GetListHashCode(c),
            
            // Defines the snapshot creation logic for a list.
            c => c == null ? null : c.ToList())
    {
    }

    /// <summary>
    /// Compares two lists for equality.
    /// </summary>
    private static bool CompareLists(List<T> a, List<T> b)
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

        // Special handling for lists of KeyValuePair types.
        if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
        {
            var keyProp = typeof(T).GetProperty("Key");
            var valueProp = typeof(T).GetProperty("Value");
            
            for (int i = 0; i < a.Count; i++)
            {
                var ai = a[i];
                var bi = b[i];
                
                if (keyProp != null)
                {
                    var ak = keyProp.GetValue(ai);
                    var bk = keyProp.GetValue(bi);
                    
                    if (valueProp != null)
                    {
                        var av = valueProp.GetValue(ai);
                        var bv = valueProp.GetValue(bi);

                        if (!EqualityComparer<object>.Default.Equals(ak, bk) ||
                            !EqualityComparer<object>.Default.Equals(av, bv))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        // Default equality comparison for other types.
        var eq = EqualityComparer<T>.Default;
        
        return !a.Where((t, i) => !eq.Equals(t, b[i])).Any();
    }

    /// <summary>
    /// Computes the hash code for a list.
    /// </summary>
    private static int GetListHashCode(List<T> c)
    {
        if (c == null)
        {
            return 0;
        }

        int hash = 0;
        
        foreach (var v in c)
        {
            hash = HashCode.Combine(hash, v?.GetHashCode() ?? 0);
        }

        return hash;
    }
}