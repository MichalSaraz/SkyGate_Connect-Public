namespace Core.SeatContext.Enums;

/// <summary>
/// Enumeration representing the position of a seat in a row.
/// </summary>
[Flags]
public enum SeatLetterEnum
{
    /// <summary>
    /// No seat assigned.
    /// </summary>
    None = 0,

    /// <summary>
    /// Seat position A.
    /// </summary>
    A = 1, // 2^0

    /// <summary>
    /// Seat position B.
    /// </summary>
    B = 2, // 2^1

    /// <summary>
    /// Seat position C.
    /// </summary>
    C = 4, // 2^2

    /// <summary>
    /// Seat position D.
    /// </summary>
    D = 8, // 2^3

    /// <summary>
    /// Seat position E.
    /// </summary>
    E = 16, // 2^4

    /// <summary>
    /// Seat position F.
    /// </summary>
    F = 32, // 2^5

    /// <summary>
    /// Seat position G.
    /// </summary>
    G = 64, // 2^6

    /// <summary>
    /// Seat position H.
    /// </summary>
    H = 128, // 2^7

    /// <summary>
    /// Seat position J.
    /// </summary>
    J = 256, // 2^8

    /// <summary>
    /// Seat position K.
    /// </summary>
    K = 512, // 2^9

    /// <summary>
    /// Seat position L.
    /// </summary>
    L = 1024 // 2^10
}