using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Infrastructure.Data.ValueConversion.Converters;

/// <summary>
/// A value converter for serializing and deserializing objects of type <typeparamref name="T"/> to and from JSON
/// strings. This converter is designed for use with Entity Framework value conversion.
/// </summary>
/// <typeparam name="T">The type of the object to be converted.</typeparam>
public class JsonValueConverter<T> : ValueConverter<T, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JsonValueConverter{T}"/> class. Configures the conversion logic for
    /// serializing an object to a JSON string and deserializing the JSON string back to an object.
    /// </summary>
    public JsonValueConverter() : base(
        
        // Converts the object to a JSON string, ignoring null values.
        v => JsonConvert.SerializeObject(v,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
        
        // Converts the JSON string back to an object, returning the default value if the string is null or empty.
        v => string.IsNullOrEmpty(v)
            ? default
            : JsonConvert.DeserializeObject<T>(v,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
    {
    }
}