using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Infrastructure.Data.ValueConversion.Comparers;

/// <summary>
/// A custom value converter for serializing and deserializing a list of key-value pairs 
/// where the key is of type <see cref="DayOfWeek"/> and the value is of type <see cref="DateTimeOffset"/>.
/// </summary>
public class DateTimeOffsetKeyValuePairJsonConverter :
    ValueConverter<List<KeyValuePair<DayOfWeek, DateTimeOffset>>, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeOffsetKeyValuePairJsonConverter"/> class.
    /// Configures the conversion logic for serializing the list to a JSON string and deserializing it back.
    /// </summary>
    public DateTimeOffsetKeyValuePairJsonConverter() : base(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<List<KeyValuePair<DayOfWeek, DateTimeOffset>>>(v) ??
             new List<KeyValuePair<DayOfWeek, DateTimeOffset>>())
    {
    }
}