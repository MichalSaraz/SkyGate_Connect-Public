using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Entities;
using Core.SeatContext.Enums;

namespace Core.SeatContext.Entities;

/// <summary>
/// Represents a seat within an aircraft, including its properties and associations.
/// </summary>
public class Seat
{
    /// <summary>
    /// Gets the unique identifier of the seat.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets or sets the passenger or item occupying the seat.
    /// </summary>
    public BasePassengerOrItem PassengerOrItem { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the passenger or item occupying the seat.
    /// </summary>
    public Guid? PassengerOrItemId { get; set; }

    /// <summary>
    /// Gets the flight associated with the seat.
    /// </summary>
    public Flight Flight { get; }

    /// <summary>
    /// Gets the unique identifier of the flight associated with the seat.
    /// </summary>
    public Guid FlightId { get; private set; }

    /// <summary>
    /// Gets or sets the seat number, which is a combination of row and letter.
    /// </summary>
    public string SeatNumber
    {
        get => $"{Row}{Letter}";

        private set
        {
            if (!string.IsNullOrEmpty(value) && value.Length >= 2)
            {
                Row = int.Parse(value[..^1]);
                Letter = (SeatLetterEnum)Enum.Parse(typeof(SeatLetterEnum), value[^1..]);
            }
        }
    }

    /// <summary>
    /// Gets the row number of the seat.
    /// </summary>
    public int Row { get; private set; }

    /// <summary>
    /// Gets the letter of the seat within the row.
    /// </summary>
    public SeatLetterEnum Letter { get; private set; }

    /// <summary>
    /// Gets the position of the seat (e.g., window, aisle, middle).
    /// </summary>
    public SeatPositionEnum Position { get; }

    /// <summary>
    /// Gets the type of the seat (e.g., standard, emergency exit, bassinet).
    /// </summary>
    public SeatTypeEnum SeatType { get; private set; }

    /// <summary>
    /// Gets or sets the flight class associated with the seat.
    /// </summary>
    public FlightClassEnum FlightClass { get; set; }

    /// <summary>
    /// Gets or sets the status of the seat (e.g., empty, occupied, blocked).
    /// </summary>
    public SeatStatusEnum SeatStatus { get; set; } = SeatStatusEnum.Empty;

    public Seat(Guid flightId, string seatNumber, SeatTypeEnum seatType, FlightClassEnum flightClass)
    {
        Id = Guid.NewGuid();
        FlightId = flightId;
        SeatNumber = seatNumber;
        SeatType = seatType;
        FlightClass = flightClass;
    }
}