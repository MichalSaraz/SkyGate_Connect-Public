using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.ValueConversion.Converters;

/// <summary>
/// Converts <see cref="DateTime"/> to and from a string representation using the "ddMMMyyyy" format.
/// This converter is designed for use with Entity Framework value conversion.
/// </summary>
public class DateTimeConverter : ValueConverter<DateTime, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeConverter"/> class.
    /// Configures the conversion logic for serializing a <see cref="DateTime"/> to a string
    /// and deserializing the string back to a <see cref="DateTime"/>.
    /// </summary>
    public DateTimeConverter()
        : base(
            // Converts a DateTime to a string using the "ddMMMyyyy" format and invariant culture.
            v => v.ToString("ddMMMyyyy", CultureInfo.InvariantCulture),
            
            // Parses a string in the "ddMMMyyyy" format back to a DateTime using invariant culture.
            v => DateTime.ParseExact(v, "ddMMMyyyy", CultureInfo.InvariantCulture))
    {
    }
}