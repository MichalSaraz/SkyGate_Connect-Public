using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.ValueConversion.Converters;

/// <summary>
/// A value converter for converting an enumeration of type <typeparamref name="T"/> to and from its string
/// representation. This converter is designed for use with Entity Framework value conversion.
/// </summary>
/// <typeparam name="T">The enumeration type to be converted.</typeparam>
public class EnumConverter<T> : ValueConverter<T, string> where T : Enum
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumConverter{T}"/> class.
    /// Configures the conversion logic for serializing an enumeration value to a string
    /// and deserializing the string back to the enumeration value.
    /// </summary>
    public EnumConverter() : base(
        
        // Converts the enumeration value to its string representation.
        v => v.ToString(),
        
        // Parses the string representation back to the enumeration value.
        v => (T)Enum.Parse(typeof(T), v))
    {
    }
}

/// <summary>
/// A value converter for converting a nullable enumeration of type <typeparamref name="T"/> to and from its string
/// representation. This converter is designed for use with Entity Framework value conversion.
/// </summary>
/// <typeparam name="T">The enumeration type to be converted.</typeparam>
public class NullableEnumValueConverter<T> : ValueConverter<T?, string> where T : struct, Enum
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NullableEnumValueConverter{T}"/> class.
    /// Configures the conversion logic for serializing a nullable enumeration value to a string
    /// and deserializing the string back to the nullable enumeration value.
    /// </summary>
    public NullableEnumValueConverter() : base(
        
        // Converts the nullable enumeration value to its string representation, or null if the value is not present.
        v => v.HasValue ? v.Value.ToString() : null,
        
        // Parses the string representation back to the nullable enumeration value, or null if the string is empty.
        v => !string.IsNullOrEmpty(v) ? (T)Enum.Parse(typeof(T), v) : null)
    {
    }
}