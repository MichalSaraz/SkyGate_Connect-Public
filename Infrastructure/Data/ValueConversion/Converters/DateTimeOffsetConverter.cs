using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.ValueConversion.Converters;

/// <summary>
/// Converts <see cref="DateTimeOffset"/> to and from <see cref="DateTime"/>.
/// This converter is designed for use with Entity Framework value conversion.
/// </summary>
public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTime>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeOffsetConverter"/> class.
    /// Configures the conversion logic for serializing a <see cref="DateTimeOffset"/> to a <see cref="DateTime"/>
    /// and deserializing the <see cref="DateTime"/> back to a <see cref="DateTimeOffset"/>.
    /// </summary>
    public DateTimeOffsetConverter() : base(
        
        // Converts a DateTimeOffset to its UTC DateTime representation.
        v => v.UtcDateTime,
        
        // Converts a DateTime to a DateTimeOffset with UTC kind.
        v => new DateTimeOffset(DateTime.SpecifyKind(v, DateTimeKind.Utc)))
    {
    }
}

/// <summary>
/// Converts nullable <see cref="DateTimeOffset"/> to and from nullable <see cref="DateTime"/>.
/// This converter is designed for use with Entity Framework value conversion.
/// </summary>
public class NullableDateTimeOffsetConverter : ValueConverter<DateTimeOffset?, DateTime?>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NullableDateTimeOffsetConverter"/> class.
    /// Configures the conversion logic for serializing a nullable <see cref="DateTimeOffset"/> to a nullable
    /// <see cref="DateTime"/> and deserializing the nullable <see cref="DateTime"/> back to a nullable
    /// <see cref="DateTimeOffset"/>.
    /// </summary>
    public NullableDateTimeOffsetConverter() : base(
        
        // Converts a nullable DateTimeOffset to its nullable UTC DateTime representation.
        v => v.HasValue ? v.Value.UtcDateTime : null,
        
        // Converts a nullable DateTime to a nullable DateTimeOffset with UTC kind.
        v => v.HasValue ? new DateTimeOffset(DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)) : null)
    {
    }
}

