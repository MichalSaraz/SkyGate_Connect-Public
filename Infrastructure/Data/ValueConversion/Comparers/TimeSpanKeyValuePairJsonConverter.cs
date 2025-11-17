using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Infrastructure.Data.ValueConversion.Comparers;

/// <summary>
/// A custom value converter for serializing and deserializing a list of key-value pairs
/// where the key is of type <see cref="DayOfWeek"/> and the value is of type <see cref="TimeSpan"/>.
/// </summary>
public class TimeSpanKeyValuePairJsonConverter : ValueConverter<List<KeyValuePair<DayOfWeek, TimeSpan>>, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeSpanKeyValuePairJsonConverter"/> class.
    /// Configures the conversion logic for serializing the list to a JSON string and deserializing it back.
    /// </summary>
    public TimeSpanKeyValuePairJsonConverter() : base(
        
        // Converts the list of key-value pairs to a JSON string.
        v => JsonConvert.SerializeObject(v),
        
        // Converts the JSON string back to a list of key-value pairs.
        v => JsonConvert.DeserializeObject<List<KeyValuePair<DayOfWeek, TimeSpan>>>(v))
    {
    }
}