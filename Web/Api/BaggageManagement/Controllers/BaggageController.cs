using Application.BaggageContext.Commands;
using Application.BaggageContext.Interfaces;
using Application.MappingContext.Interfaces;
using Core.BaggageContext.Dtos;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Enums;
using Core.FlightContext.Flights.Entities;
using Core.OperationResults;
using Core.PassengerContext.Passengers.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Api.BaggageManagement.Logging;
using Web.Api.BaggageManagement.Models;
using Web.Extensions;

namespace Web.Api.BaggageManagement.Controllers;

/// <summary>
/// Controller responsible for baggage management operations.
/// Exposes endpoints to query, create, update and delete baggage records for flights and passengers.
/// </summary>
[ApiController]
[Route("baggage-management")]
public class BaggageController : ControllerBase
{
    private readonly IBaggageQuery _baggageQuery;
    private readonly IBaggageValidator _baggageValidator;
    private readonly IMappingService _mappingService;
    private readonly IBaggageFacade _baggageFacade;
    private readonly ILogger<BaggageController> _logger;

    public BaggageController(
        IBaggageQuery baggageQuery,
        IBaggageValidator baggageValidator,
        IMappingService mappingService,
        IBaggageFacade baggageFacade,
        ILogger<BaggageController> logger)
    {
        _baggageQuery = baggageQuery;
        _baggageValidator = baggageValidator;
        _mappingService = mappingService;
        _baggageFacade = baggageFacade;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves baggage details by tag number.
    /// </summary>
    /// <param name="tagNumber">Baggage tag number to look up.</param>
    /// <returns>
    /// An <see cref="ActionResult{BaggageDetailsDto}"/> containing the baggage details DTO when found,
    /// or an appropriate error result (e.g. 404) when not found.
    /// </returns>
    [HttpGet("tag-number/{tagNumber}/details")]
    public async Task<ActionResult<BaggageDetailsDto>> GetBaggageDetails(string tagNumber)
    {
        var baggageResult = await _baggageQuery.GetBaggageDetailsByTagNumberAsync(tagNumber);
            
        return !baggageResult.TryGetData<Baggage>(out var baggage)
            ? this.ToActionResult(baggageResult.NoDataResponse)
            : this.ToActionResult(
                _mappingService.MapToDtoWithFlightId<Baggage, BaggageDetailsDto>(baggage,
                    baggage.Flights.First().FlightId));
    }

    /// <summary>
    /// Retrieves all baggage associated with the specified flight.
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing a list of <see cref="BaggageOverviewDto"/> instances for all baggage
    /// associated with the flight.
    /// </returns>
    [HttpGet("flight/{flightId:guid}/all-bags")]
    public async Task<ActionResult<List<BaggageOverviewDto>>> GetAllBags(Guid flightId)
    {
        var baggageResult = await _baggageQuery.GetAllBagsForFlightAsync(flightId);
            
        return !baggageResult.TryGetData<List<Baggage>>(out var bagList)
            ? this.ToActionResult(baggageResult.NoDataResponse)
            : this.ToActionResult(
                _mappingService.MapToListDtoWithFlightId<Baggage, BaggageOverviewDto>(bagList, flightId));
    }

    /// <summary>
    /// Retrieves all baggage of the specified special bag type for a given flight.
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <param name="specialBagType">The special bag type to filter by.</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing a list of <see cref="BaggageOverviewDto"/> instances that match
    /// the specified special bag type.
    /// </returns>
    [HttpGet("flight/{flightId:guid}/special-bag-type/{specialBagType}")]
    public async Task<ActionResult<List<BaggageOverviewDto>>> GetAllBagsBySpecialBagType(Guid flightId,
        SpecialBagEnum specialBagType)
    {
        var baggageResult = await _baggageQuery.GetBagsBySpecialBagTypeAsync(flightId, specialBagType);
            
        return !baggageResult.TryGetData<List<Baggage>>(out var bagList)
            ? this.ToActionResult(baggageResult.NoDataResponse)
            : this.ToActionResult(
                _mappingService.MapToListDtoWithFlightId<Baggage, BaggageOverviewDto>(bagList, flightId));
    }

    /// <summary>
    /// Retrieves all baggage of the specified baggage type for a given flight.
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <param name="baggageType">The baggage type to filter by.</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing a list of <see cref="BaggageOverviewDto"/> instances that match
    /// the specified baggage type.
    /// </returns>
    [HttpGet("flight/{flightId:guid}/baggage-type/{baggageType}")]
    public async Task<ActionResult<List<BaggageOverviewDto>>> GetBagsByBaggageType(Guid flightId,
        BaggageTypeEnum baggageType)
    {
        var baggageResult = await _baggageQuery.GetBagsByBaggageTypeAsync(flightId, baggageType);

        return !baggageResult.TryGetData<List<Baggage>>(out var bagList)
            ? this.ToActionResult(baggageResult.NoDataResponse)
            : this.ToActionResult(
                _mappingService.MapToListDtoWithFlightId<Baggage, BaggageOverviewDto>(bagList, flightId));
    }

    /// <summary>
    /// Retrieves all inactive baggage for a specified flight (bags without a valid tag).
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing a list of <see cref="BaggageOverviewDto"/> instances for inactive
    /// baggage.
    /// </returns>
    [HttpGet("flight/{flightId:guid}/inactive-bags")]
    public async Task<ActionResult<List<BaggageOverviewDto>>> GetInactiveBags(Guid flightId)
    {
        var baggageResult = await _baggageQuery.GetInactiveBagsAsync(flightId);

        return !baggageResult.TryGetData<List<Baggage>>(out var bagList)
            ? this.ToActionResult(baggageResult.NoDataResponse)
            : this.ToActionResult(
                _mappingService.MapToListDtoWithFlightId<Baggage, BaggageOverviewDto>(bagList, flightId));
    }

    /// <summary>
    /// Retrieves all baggage that have onward connections for a given flight.
    /// </summary>
    /// <param name="flightId">The flight identifier.</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing a list of <see cref="BaggageDetailsDto"/> instances for baggage
    /// with onward connections.
    /// </returns>
    [HttpGet("flight/{flightId:guid}/onward-connections")]
    public async Task<ActionResult<List<BaggageDetailsDto>>> GetBagsWithOnwardConnection(Guid flightId)
    {
        var baggageResult = await _baggageQuery.GetBagsWithOnwardConnectionsAsync(flightId);
            
        return !baggageResult.TryGetData<List<Baggage>>(out var bagList) 
            ? this.ToActionResult(baggageResult.NoDataResponse)
            : this.ToActionResult(
                _mappingService.MapToListDtoWithFlightId<Baggage, BaggageDetailsDto>(bagList, flightId));
    }
        
    /// <summary>
    /// Adds baggage for a passenger on a specific flight.
    /// </summary>
    /// <param name="passengerId">The passenger identifier.</param>
    /// <param name="flightId">The flight identifier.</param>
    /// <param name="addBaggageModels">The list of baggage models to create.</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing a list of <see cref="BaggageOverviewDto"/> instances
    /// representing the added baggage.
    /// </returns>
    [HttpPost("passenger/{passengerId:guid}/flight/{flightId:guid}/add-baggage")]
    public async Task<ActionResult<List<BaggageOverviewDto>>> AddBaggage(Guid passengerId, Guid flightId,
        [FromBody] List<AddBaggageModel> addBaggageModels)
    {
        _logger.AddBaggageRequestReceived(passengerId, flightId, addBaggageModels.Count);
            
        var createCommands = _mappingService.MapToListDto<AddBaggageModel, CreateBaggageCommand>(addBaggageModels);

        var validationResult =
            await _baggageValidator.ValidateAddBaggage(createCommands, passengerId, flightId);
        if (!validationResult.TryGetData<(Passenger, Flight)>(out var passengerAndFlight))
        {
            return this.ToActionResult(validationResult.NoDataResponse);
        }

        var (passenger, flight) = passengerAndFlight;
        var resultDtos =
            await _baggageFacade.AddBaggageAsync(passenger, flight, createCommands, flightId, passengerId);
            
        return this.ToActionResult(resultDtos);
    }

    /// <summary>
    /// Edits baggage information for a passenger.
    /// </summary>
    /// <param name="passengerId">The passenger identifier.</param>
    /// <param name="flightId">The flight identifier.</param>
    /// <param name="editBaggageModels">List of edit commands specifying changes to apply.</param>
    /// <returns>
    /// An <see cref="ActionResult"/> containing a list of updated <see cref="BaggageOverviewDto"/> instances.
    /// </returns>
    [HttpPut("passenger/{passengerId:guid}/flight/{flightId:guid}/edit-baggage")]
    public async Task<ActionResult<List<BaggageOverviewDto>>> EditBaggage(Guid passengerId, Guid flightId,
        [FromBody] List<EditBaggageModel> editBaggageModels)
    {
        _logger.EditBaggageRequestReceived(passengerId, flightId, editBaggageModels.Count);
            
        var editCommands = _mappingService.MapToListDto<EditBaggageModel, EditBaggageCommand>(editBaggageModels);

        var validationResult = await _baggageValidator.ValidateEditBaggage(editCommands, passengerId);
        if (!validationResult.TryGetData<IReadOnlyList<Baggage>>(out var baggageToEdit))
        {
            return this.ToActionResult(validationResult.NoDataResponse);
        }
            
        var updatedBaggageListDto =
            await _baggageFacade.EditBaggageAsync(editCommands, baggageToEdit, flightId, passengerId);
            
        return this.ToActionResult(updatedBaggageListDto);
    }

    /// <summary>
    /// Deletes the selected baggage for a specific passenger.
    /// </summary>
    /// <param name="passengerId">The passenger identifier.</param>
    /// <param name="flightId">The flight identifier.</param>
    /// <param name="baggageIds">A list of baggage identifiers to delete.</param>
    /// <returns>
    /// A <see cref="NoContentResult"/> if the deletion was successful; otherwise an appropriate error result.
    /// </returns>
    [HttpDelete("passenger/{passengerId:guid}/flight/{flightId:guid}/delete-baggage")]
    public async Task<ActionResult> DeleteSelectedBaggage(Guid passengerId, Guid flightId,
        [FromBody] List<Guid> baggageIds)
    {
        _logger.DeleteBaggageRequestReceived(passengerId, flightId, baggageIds.Count);
            
        var validationResult = await _baggageValidator.ValidateDeleteBaggage(baggageIds, passengerId);
        if (!validationResult.TryGetData<IReadOnlyList<Baggage>>(out var bagsToDelete))
        {
            return this.ToActionResult(validationResult.NoDataResponse);
        }
            
        await _baggageFacade.DeleteBaggageAsync(bagsToDelete, flightId, passengerId);
            
        return this.ToActionResult();
    }
}