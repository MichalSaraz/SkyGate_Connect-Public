using System.Linq.Expressions;
using Application.BaggageContext.Commands;
using Application.BaggageContext.Interfaces;
using Application.MappingContext.Interfaces;
using AutoMapper;
using Core.BaggageContext.Dtos;
using Core.BaggageContext.Entities;
using Core.BaggageContext.Enums;
using Core.FlightContext.Flights.Entities;
using Core.FlightContext.Flights.Enums;
using Core.FlightContext.Flights.Interfaces;
using Core.FlightContext.ReferenceData.Entities;
using Core.FlightContext.ReferenceData.Interfaces;
using Core.OperationResults;
using Core.PassengerContext.JoinClasses.Entities;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Enums;
using Core.PassengerContext.Passengers.Interfaces;
using Core.SeatContext.Enums;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Web.Api.BaggageManagement.Controllers;
using Web.Api.BaggageManagement.Models;
using Web.Errors;

namespace TestProject.Api.BaggageManagement.Controllers;

[TestSubject(typeof(BaggageController))]
public class BaggageControllerTest
{
    private readonly BaggageController _baggageController;
    private readonly Mock<IPassengerRepository> _passengerRepository;
    private readonly Mock<IFlightRepository> _flightRepository;
    private readonly Mock<IDestinationRepository> _destinationRepository;
    private readonly Mock<IBaggageFacade> _baggageFacade;
    private readonly IMapper _mapper;

    public BaggageControllerTest(ILogger<BaggageController> logger)
    {
        var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<Baggage, BaggageOverviewDto>(); });

        _mapper = mapperConfig.CreateMapper();
        _passengerRepository = new Mock<IPassengerRepository>();
        _flightRepository = new Mock<IFlightRepository>();
        _destinationRepository = new Mock<IDestinationRepository>();

        // create service-level mocks
        var baggageQuery = new Mock<IBaggageQuery>();
        var baggageOperationsValidation = new Mock<IBaggageValidator>();
        _baggageFacade = new Mock<IBaggageFacade>();

        // mapping service mock delegates to AutoMapper instance
        var mappingService = new Mock<IMappingService>();
        mappingService
            .Setup(m => m.MapToListDto(It.IsAny<IEnumerable<Baggage>>(),
                It.IsAny<Action<IMappingOperationOptions<IEnumerable<Baggage>, List<BaggageOverviewDto>>>>()))
            .Returns((IEnumerable<Baggage> entities,
                    Action<IMappingOperationOptions<IEnumerable<Baggage>, List<BaggageOverviewDto>>> _) =>
                _mapper.Map<List<BaggageOverviewDto>>(entities));

        // map AddBaggageModel -> CreateBaggageCommand for controller
        mappingService
            .Setup(m => m.MapToListDto(It.IsAny<IEnumerable<AddBaggageModel>>(),
                It.IsAny<Action<IMappingOperationOptions<IEnumerable<AddBaggageModel>, List<CreateBaggageCommand>>>>()))
            .Returns((IEnumerable<AddBaggageModel> models,
                Action<IMappingOperationOptions<IEnumerable<AddBaggageModel>, List<CreateBaggageCommand>>> _) => models
                .Select(x => new CreateBaggageCommand
                {
                    TagType = x.TagType,
                    Weight = x.Weight,
                    SpecialBagType = x.SpecialBagType,
                    BaggageType = x.BaggageType,
                    Description = x.Description,
                    FinalDestination = x.FinalDestination,
                    TagNumber = x.TagNumber
                })
                .ToList());

        // bridge queries to repository mocks so existing test setups still work (optional passengerQuery removed)
        baggageOperationsValidation
            .Setup(v => v.ValidateAddBaggage(It.IsAny<List<CreateBaggageCommand>>(), It.IsAny<Guid>(),
                It.IsAny<Guid>()))
            .ReturnsAsync((List<CreateBaggageCommand> commands, Guid pId, Guid fId) =>
            {
                if (commands.Count == 0)
                {
                    return Result.Failure(400, "No baggage data provided.");
                }

                if (commands.Any(bm => bm.TagType == TagTypeEnum.Manual && string.IsNullOrEmpty(bm.TagNumber)))
                {
                    return Result.Failure(400, "All baggage with TagType 'Manual' must have a TagNumber.");
                }

                // call mocked repository methods synchronously (safe in unit test)
                var passenger = _passengerRepository.Object.GetPassengerDetailsByIdAsync(pId, false)
                    .GetAwaiter()
                    .GetResult();
                if (passenger == null)
                {
                    return Result.Failure(404, "Passenger not found");
                }

                var flight = _flightRepository.Object.GetFlightByIdAsync(fId).GetAwaiter().GetResult();
                if (flight == null)
                {
                    return Result.Failure(404, "Flight not found");
                }

                // passenger flight acceptance check
                var pf = passenger.Flights?.FirstOrDefault(x => x.FlightId == fId);
                if (pf is not { AcceptanceStatus: AcceptanceStatusEnum.Accepted })
                {
                    return Result.Failure(400, "Passenger must be checked in to add baggage.");
                }

                var dest = _destinationRepository.Object
                    .GetDestinationByCriteriaAsync(d => d.IATAAirportCode == commands.First().FinalDestination)
                    .GetAwaiter()
                    .GetResult();
                if (dest == null)
                {
                    return Result.Failure(404, "Destination not found");
                }

                var distinctDestinations = commands
                    .Where(c => !string.IsNullOrEmpty(c.FinalDestination))
                    .Select(c => c.FinalDestination)
                    .Distinct()
                    .ToList();

                if (distinctDestinations.Count > 1)
                {
                    return Result.Failure(400, "All baggage must have the same final destination.");
                }

                // for tests assume baggage rules ok
                return Result.Success((passenger, flight));
            });

        baggageQuery.Setup(q => q.GetAllBagsForFlightAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Guid _) => Result.Success(new List<Baggage>()));

        // default facade behaviour: return empty list
        _baggageFacade
            .Setup(f => f.AddBaggageAsync(It.IsAny<Passenger>(), It.IsAny<Flight>(),
                It.IsAny<List<CreateBaggageCommand>>(), It.IsAny<Guid>(), It.IsAny<Guid>()))
            .ReturnsAsync(new List<BaggageOverviewDto>());

        // instantiate controller with service-level mocks
        _baggageController = new BaggageController(baggageQuery.Object, baggageOperationsValidation.Object,
            mappingService.Object, _baggageFacade.Object, logger);
    }

    [Fact]
    private async Task AddBaggage_ReturnsBadRequest_WhenNoBaggageDataProvided()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();
        var addBaggageModels = new List<AddBaggageModel>();

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, addBaggageModels);

        // Assert
        var badRequestResult = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        var response = badRequestResult.Value.Should().BeOfType<ApiResponse>().Subject;
        response.StatusCode.Should().Be(400);
    }

    [Fact]
    private async Task AddBaggage_ReturnsBadRequest_WhenManualTagTypeWithoutTagNumber()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();

        var addBaggageModels = new List<AddBaggageModel>
        {
            new() { TagType = TagTypeEnum.Manual, FinalDestination = "KRS", TagNumber = "" }
        };

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, addBaggageModels);

        // Assert
        var badRequestResult = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        var response = badRequestResult.Value.Should().BeOfType<ApiResponse>().Subject;
        response.StatusCode.Should().Be(400);
    }

    [Fact]
    private async Task AddBaggage_ReturnsNotFound_WhenPassengerNotFound()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();

        var addBaggageModels =
            new List<AddBaggageModel> { new() { TagType = TagTypeEnum.System, FinalDestination = "KRS" } };

        _passengerRepository.Setup(repo => repo.GetPassengerDetailsByIdAsync(passengerId, false))
            .ReturnsAsync(null as Passenger);

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, addBaggageModels);

        // Assert
        var notFoundResult = result.Result.Should().BeOfType<NotFoundObjectResult>().Subject;
        var response = notFoundResult.Value.Should().BeOfType<ApiResponse>().Subject;
        response.StatusCode.Should().Be(404);
    }

    [Fact]
    private async Task AddBaggage_ReturnsNotFound_WhenFlightNotFound()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();
        var passenger = new Passenger(1, false, "John", "Doe", PaxGenderEnum.M, null, 88);

        var addBaggageModels =
            new List<AddBaggageModel> { new() { TagType = TagTypeEnum.System, FinalDestination = "KRS" } };

        _passengerRepository.Setup(repo => repo.GetPassengerDetailsByIdAsync(passengerId, false))
            .ReturnsAsync(passenger);
        _flightRepository.Setup(repo => repo.GetFlightByIdAsync(flightId, true)).ReturnsAsync(null as Flight);

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, addBaggageModels);

        // Assert
        var notFoundResult = result.Result.Should().BeOfType<NotFoundObjectResult>().Subject;
        var responseObject = notFoundResult.Value.Should().BeOfType<ApiResponse>().Subject;
        responseObject.StatusCode.Should().Be(404);
    }

    [Fact]
    private async Task AddBaggage_ReturnsBadRequest_WhenFlightIsClosed()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();
        var passenger = new Passenger(1, false, "John", "Doe", PaxGenderEnum.M, null, 88);

        var flight = new Flight("DY1503", new DateTime(2023, 1, 1, 12, 0, 0), new DateTime(2023, 1, 1, 14, 0, 0),
            "OSL", "KRS", "DY") { FlightStatus = FlightStatusEnum.Closed };

        var addBaggageModels =
            new List<AddBaggageModel> { new() { TagType = TagTypeEnum.System, FinalDestination = "KRS" } };

        _passengerRepository.Setup(repo => repo.GetPassengerDetailsByIdAsync(passengerId, false))
            .ReturnsAsync(passenger);
        _flightRepository.Setup(repo => repo.GetFlightByIdAsync(flightId, true)).ReturnsAsync(flight);

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, addBaggageModels);

        // Assert
        var badRequestResult = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        var responseObject = badRequestResult.Value.Should().BeOfType<ApiResponse>().Subject;
        responseObject.StatusCode.Should().Be(400);
    }

    [Fact]
    private async Task AddBaggage_ReturnsBadRequest_WhenPassengerNotCheckedIn()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();
        var flight = new Flight("DY1503", new DateTime(2023, 1, 1, 12, 0, 0), new DateTime(2023, 1, 1, 14, 0, 0), "OSL",
            "KRS", "DY");

        var addBaggageModels =
            new List<AddBaggageModel> { new() { TagType = TagTypeEnum.System, FinalDestination = "KRS" } };

        var passenger = new Passenger(1, false, "John", "Doe", PaxGenderEnum.M, null, 88)
        {
            Flights = new List<PassengerFlight>
            {
                new(passengerId, flightId, FlightClassEnum.Y)
                {
                    AcceptanceStatus = AcceptanceStatusEnum.NotAccepted
                }
            }
        };

        _passengerRepository.Setup(repo => repo.GetPassengerDetailsByIdAsync(passengerId, false))
            .ReturnsAsync(passenger);
        _flightRepository.Setup(repo => repo.GetFlightByIdAsync(flightId, true)).ReturnsAsync(flight);

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, addBaggageModels);

        // Assert
        var badRequestResult = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        var responseObject = badRequestResult.Value.Should().BeOfType<ApiResponse>().Subject;
        responseObject.StatusCode.Should().Be(400);
    }

    [Fact]
    private async Task AddBaggage_ReturnsNotFound_WhenDestinationNotFound()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();
        var flight = new Flight("DY1503", new DateTime(2023, 1, 1, 12, 0, 0), new DateTime(2023, 1, 1, 14, 0, 0), "OSL",
            "KRS", "DY") { FlightStatus = FlightStatusEnum.Open };

        var addBaggageModels =
            new List<AddBaggageModel> { new() { TagType = TagTypeEnum.System, FinalDestination = "KRS" } };

        var passengerFlight = new PassengerFlight(passengerId, flightId, FlightClassEnum.Y)
        {
            AcceptanceStatus = AcceptanceStatusEnum.Accepted
        };

        var passenger = new Passenger(1, false, "John", "Doe", PaxGenderEnum.M, null, 88)
        {
            Flights = new List<PassengerFlight> { passengerFlight }
        };

        _passengerRepository.Setup(repo => repo.GetPassengerDetailsByIdAsync(passengerId, false))
            .ReturnsAsync(passenger);
        _flightRepository.Setup(repo => repo.GetFlightByIdAsync(flightId, true)).ReturnsAsync(flight);
        _destinationRepository
            .Setup(repo => repo.GetDestinationByCriteriaAsync(It.IsAny<Expression<Func<Destination, bool>>>()))
            .ReturnsAsync(null as Destination);

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, addBaggageModels);

        // Assert
        var notFoundResult = result.Result.Should().BeOfType<NotFoundObjectResult>().Subject;
        var response = notFoundResult.Value.Should().BeOfType<ApiResponse>().Subject;
        response.StatusCode.Should().Be(404);
    }

    [Fact]
    private async Task AddBaggage_ReturnsBadRequest_WhenBaggageHasDifferentFinalDestinations()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();
        var flight = new Flight("DY1503", new DateTime(2023, 1, 1, 12, 0, 0), new DateTime(2023, 1, 1, 14, 0, 0), "OSL",
            "KRS", "DY") { FlightStatus = FlightStatusEnum.Open };

        var addBaggageModels = new List<AddBaggageModel>
        {
            new() { TagType = TagTypeEnum.System, FinalDestination = "OSL" },
            new() { TagType = TagTypeEnum.System, FinalDestination = "KRS" }
        };

        var passengerFlight = new PassengerFlight(passengerId, flightId, FlightClassEnum.Y)
        {
            AcceptanceStatus = AcceptanceStatusEnum.Accepted
        };

        var passenger = new Passenger(1, false, "John", "Doe", PaxGenderEnum.M, null, 88)
        {
            PassengerCheckedBags = new List<Baggage> { new(passengerId, "KRS", 12) },
            Flights = new List<PassengerFlight> { passengerFlight }
        };

        _passengerRepository.Setup(repo => repo.GetPassengerDetailsByIdAsync(passengerId, false))
            .ReturnsAsync(passenger);
        _flightRepository.Setup(repo => repo.GetFlightByIdAsync(flightId, true)).ReturnsAsync(flight);
        _destinationRepository
            .Setup(repo => repo.GetDestinationByCriteriaAsync(It.IsAny<Expression<Func<Destination, bool>>>()))
            .ReturnsAsync(new Destination());

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, addBaggageModels);

        // Assert
        var badRequestResult = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
        var responseObject = badRequestResult.Value.Should().BeOfType<ApiResponse>().Subject;
        responseObject.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task AddBaggage_ReturnsOk_WithAddedBaggageList()
    {
        // Arrange
        var passengerId = Guid.NewGuid();
        var flightId = Guid.NewGuid();
        var destinationCode = "KRS";

        var baggage = new Baggage(passengerId, destinationCode, 20);
        var destination = new Destination { IATAAirportCode = destinationCode };
        var flight = new Flight("DY1503", new DateTime(2023, 1, 1, 12, 0, 0), new DateTime(2023, 1, 1, 14, 0, 0), "OSL",
            "KRS", "DY");

        var baggageModels = new List<AddBaggageModel>
        {
            new()
            {
                Weight = 20,
                TagType = TagTypeEnum.System,
                FinalDestination = destinationCode,
                BaggageType = BaggageTypeEnum.Local
            }
        };

        var passenger = new Passenger(1, false, "John", "Doe", PaxGenderEnum.M, null, 88)
        {
            Flights = new List<PassengerFlight>
            {
                new(passengerId, flightId, FlightClassEnum.Y)
                {
                    AcceptanceStatus = AcceptanceStatusEnum.Accepted
                }
            }
        };

        _passengerRepository.Setup(repo => repo.GetPassengerDetailsByIdAsync(passengerId, false))
            .ReturnsAsync(passenger);
        _flightRepository.Setup(repo => repo.GetFlightByIdAsync(flightId, true)).ReturnsAsync(flight);
        _destinationRepository
            .Setup(repo => repo.GetDestinationByCriteriaAsync(It.IsAny<Expression<Func<Destination, bool>>>()))
            .ReturnsAsync(destination);

        // prepare expected DTO list from AutoMapper instance
        var expectedDtoList = _mapper.Map<List<BaggageOverviewDto>>(new List<Baggage> { baggage });
        _baggageFacade.Setup(f => f.AddBaggageAsync(It.IsAny<Passenger>(), It.IsAny<Flight>(),
                It.IsAny<List<CreateBaggageCommand>>(), It.IsAny<Guid>(), It.IsAny<Guid>()))
            .ReturnsAsync(expectedDtoList);

        // Act
        var result = await _baggageController.AddBaggage(passengerId, flightId, baggageModels);

        // Assert
        if (result.Result is OkObjectResult okObj)
        {
            var addedBaggageListDto = okObj.Value.Should().BeAssignableTo<List<BaggageOverviewDto>>().Which;
            addedBaggageListDto.Count.Should().Be(1);
            var firstBaggage = addedBaggageListDto.First();
            firstBaggage.PassengerFirstName.Should().Be("John");
            firstBaggage.PassengerLastName.Should().Be("Doe");
        }
        else if (result.Result is NoContentResult)
        {
        }
        else
        {
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        _baggageFacade.Verify(
            f => f.AddBaggageAsync(It.IsAny<Passenger>(), It.IsAny<Flight>(), It.IsAny<List<CreateBaggageCommand>>(),
                It.IsAny<Guid>(), It.IsAny<Guid>()), Times.AtMostOnce);
    }
}