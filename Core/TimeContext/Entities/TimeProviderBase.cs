using System.Globalization;
using Core.TimeContext.Interfaces;

namespace Core.TimeContext.Entities;

/// <summary>
/// Provides a base implementation for a time provider, allowing for date and time parsing
/// with customizable formats and default values.
/// </summary>
public abstract class TimeProviderBase : ITimeProvider
{
    /// <summary>
    /// Gets the current date and time.
    /// </summary>
    public virtual DateTime Now => DateTime.Now;

    /// <summary>
    /// Parses a date string into a <see cref="DateTime"/> object, with optional formats and a default time value.
    /// </summary>
    /// <param name="input">The date string to parse.</param>
    /// <param name="useFormatsWithYear">Indicates whether to use formats that include the year.</param>
    /// <param name="defaultTime">The default time to use if no time is specified in the input.</param>
    /// <returns>A <see cref="DateTime"/> object representing the parsed date and time.</returns>
    /// <exception cref="ArgumentException">Thrown when the input date or time format is invalid.</exception>
    public virtual DateTime ParseDate(string input, bool useFormatsWithYear = false, string defaultTime = "0:00:00")
    {
        // Define date formats without and with year
        string[] formatsDateOnly = { "dMMM", "DDMMM", "ddMMM" };
        string[] formatsDateWithYear = { "dMMMyyyy", "ddMMMyyyy", "DDMMMyyyy" };

        // Select the appropriate formats based on the useFormatsWithYear flag
        string[] formatsToUse = useFormatsWithYear ? formatsDateWithYear : formatsDateOnly;

        // Attempt to parse the input date string
        var isValidDate = DateTime.TryParseExact(input, formatsToUse, CultureInfo.InvariantCulture, DateTimeStyles.None,
            out var parsedDate);

        if (!isValidDate)
        {
            throw new ArgumentException("Invalid date format");
        }

        TimeSpan parsedTime;

        // Parse the default time or use TimeSpan.Zero if the default time is "0:00:00"
        if (defaultTime == "0:00:00")
        {
            parsedTime = TimeSpan.Zero;
        }
        else
        {
            var isValidTime = TimeSpan.TryParseExact(defaultTime, @"hh\:mm", CultureInfo.InvariantCulture,
                out parsedTime);
            if (!isValidTime)
            {
                throw new ArgumentException("Invalid time format");
            }
        }

        // Combine the parsed date and time
        var result = parsedDate.Date + parsedTime;

        // Adjust the parsed date to the current year
        return ParseDateWithCurrentYear(result);
    }

    /// <summary>
    /// Adjusts the given date to the current year while preserving the month, day, and time.
    /// </summary>
    /// <param name="date">The date to adjust.</param>
    /// <returns>A new <see cref="DateTime"/> object with the current year.</returns>
    protected virtual DateTime ParseDateWithCurrentYear(DateTime date)
    {
        return new DateTime(Now.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
    }
}