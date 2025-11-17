namespace Core.TimeContext.Interfaces;

/// <summary>
/// Provides an abstraction for time-related operations.
/// </summary>
public interface ITimeProvider
{
    /// <summary>
    /// Gets the current system time.
    /// </summary>
    DateTime Now { get; }

    /// <summary>
    /// Parses the input string as a date, with an optional default time and format setting.
    /// </summary>
    /// <param name="input">The input string representation of the date.</param>
    /// <param name="useFormatsWithYear">Specifies whether to use date formats that include the year. Default is false.</param>
    /// <param name="defaultTime">The default time to use if the input does not contain a time component. Default is
    /// "0:00:00".</param>
    /// <returns>
    /// A <see cref="DateTime"/> parsed from the input.
    /// </returns>
    DateTime ParseDate(string input, bool useFormatsWithYear = false, string defaultTime = "0:00:00");
}