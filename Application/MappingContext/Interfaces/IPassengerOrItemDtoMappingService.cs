using Core.FlightContext.Flights.Entities;
using Core.PassengerContext.Passengers.Dtos;
using Core.PassengerContext.Passengers.Entities;

namespace Application.MappingContext.Interfaces;

/// <summary>
/// Mapping service contract for converting domain passenger-or-item entities into their corresponding DTOs
/// for API responses or internal use. Provides methods to map single entities, collections, and specialised
/// payloads (passenger details and infant response DTOs) enriched with flight-specific information.
/// </summary>
public interface IPassengerOrItemDtoMappingService
{
    /// <summary>
    /// Maps a single passenger or item entity to an appropriate DTO using information from the provided
    /// <see cref="BaseFlight"/>. The concrete DTO type depends on the runtime type of <paramref name="item"/>
    /// and the <paramref name="displayDetails"/> flag.
    /// </summary>
    /// <param name="item">The passenger-or-item domain entity to map (e.g. <see cref="Passenger"/>,
    /// <see cref="Infant"/>, <see cref="CabinBaggageRequiringSeat"/> or <see cref="ExtraSeat"/>).</param>
    /// <param name="flight">Flight information used to enrich the DTO.</param>
    /// <param name="displayDetails">If <c>true</c> a detailed DTO (e.g. <see cref="PassengerDetailsDto"/>) is returned;
    /// otherwise an overview DTO is returned.</param>
    /// <returns>
    /// A DTO derived from <see cref="BasePassengerOrItemDto"/> matching the concrete <paramref name="item"/>, or
    /// <c>null</c> when the <paramref name="item"/> cannot be mapped.
    /// </returns>
    BasePassengerOrItemDto? MapSinglePassengerOrItemToDto(BasePassengerOrItem item, BaseFlight flight,
        bool displayDetails = true);

    /// <summary>
    /// Maps a collection of passenger-or-item entities to a list of DTOs. Each element is mapped using
    /// <see cref="MapSinglePassengerOrItemToDto"/> and the result excludes any null mappings.
    /// </summary>
    /// <param name="passengerOrItems">The entities to map.</param>
    /// <param name="flight">Flight information used to enrich each DTO.</param>
    /// <param name="displayDetails">If <c>true</c> detailed DTOs will be produced for each entity.</param>
    /// <returns>
    /// A list of DTO instances. The returned list is never <c>null</c>; if no mappings succeeded an empty list is
    /// returned.
    /// </returns>
    List<BasePassengerOrItemDto> MapPassengersOrItemsToDto(IEnumerable<BasePassengerOrItem> passengerOrItems,
        BaseFlight flight, bool displayDetails = true);

    /// <summary>
    /// Loads (if required) and maps a passenger entity to a <see cref="PassengerDetailsDto"/>. This method
    /// may perform repository lookups to ensure the mapped DTO contains up-to-date data for the specified flight.
    /// </summary>
    /// <param name="noRecPassenger">The passenger entity to map.</param>
    /// <param name="selectedFlight">The flight associated with the DTO.</param>
    /// <param name="flightId">The identifier of the flight (used to load passenger details where necessary).</param>
    /// <returns>
    /// A <see cref="Task{PassengerDetailsDto}"/> that resolves to a fully populated <see cref="PassengerDetailsDto"/>.
    /// </returns>
    Task<PassengerDetailsDto> MapToDtoAsync(Passenger noRecPassenger, Flight selectedFlight, Guid flightId);

    /// <summary>
    /// Creates an <see cref="InfantResponseDto"/> for a given passenger and flight. The response contains
    /// infant-related information based on the mapped <see cref="PassengerDetailsDto"/>.
    /// </summary>
    /// <param name="passenger">The parent passenger whose infant information will be included.</param>
    /// <param name="flight">The flight used to enrich the mapped DTO.</param>
    /// <returns>
    /// An <see cref="InfantResponseDto"/> containing infant-specific DTOs or empty/null properties when not
    /// applicable.
    /// </returns>
    InfantResponseDto MapInfantToResponseDto(Passenger passenger, BaseFlight flight);
}