namespace Core.TimeContext.Entities;

/// <summary>
/// A test implementation of the time provider, allowing for simulated time manipulation.
/// </summary>
public class TestTimeProvider : TimeProviderBase
{
    /// <summary>
    /// Gets the current simulated time.
    /// </summary>
    public new DateTime Now { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestTimeProvider"/> class and sets the initial simulated time to
    /// October 15, 2023.
    /// </summary>
    public TestTimeProvider()
    {
        _SetSimulatedTime(2023, 10, 15);
    }

    /// <summary>
    /// Sets the simulated time to the specified year, month, and day.
    /// </summary>
    private void _SetSimulatedTime(int year, int month, int day)
    {
        Now = new DateTime(year, month, day);
    }

    /// <summary>
    /// Parses a date and sets its year to the current simulated year (2023).
    /// </summary>
    /// <param name="date">The date to parse.</param>
    /// <returns>
    /// A new <see cref="DateTime"/> instance with the current year and the same month, day, hour, minute,
    /// and second as the input date.
    /// </returns>
    protected override DateTime ParseDateWithCurrentYear(DateTime date)
    {
        var currentYear = 2023;
        return new DateTime(currentYear, date.Month, date.Day, date.Hour, date.Minute, date.Second);
    }
}