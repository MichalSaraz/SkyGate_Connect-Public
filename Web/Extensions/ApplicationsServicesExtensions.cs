using Application.ActionHistoryContext.Interfaces;
using Application.ActionHistoryContext.Services;
using Application.BaggageContext.Facades;
using Application.BaggageContext.Interfaces;
using Application.BaggageContext.Queries;
using Application.BaggageContext.Rules;
using Application.BaggageContext.Services;
using Application.BaggageContext.Validators;
using Application.FlightContext.Interfaces;
using Application.FlightContext.Queries;
using Application.FlightContext.Rules;
using Application.FlightContext.Services;
using Application.FlightContext.Validators;
using Application.Identity.Interfaces;
using Application.MappingContext.Interfaces;
using Application.MappingContext.Services;
using Application.PassengerContext.Comments.Interfaces;
using Application.PassengerContext.Comments.Queries;
using Application.PassengerContext.Comments.Services;
using Application.PassengerContext.Comments.Validators;
using Application.PassengerContext.Passengers.Interfaces;
using Application.PassengerContext.Passengers.Queries;
using Application.PassengerContext.Passengers.Rules;
using Application.PassengerContext.Passengers.Services;
using Application.PassengerContext.Passengers.Validators;
using Application.PassengerContext.SpecialServiceRequests.Interfaces;
using Application.PassengerContext.SpecialServiceRequests.Queries;
using Application.PassengerContext.SpecialServiceRequests.Services;
using Application.PassengerContext.SpecialServiceRequests.Validators;
using Application.PassengerContext.TravelDocuments.Interfaces;
using Application.PassengerContext.TravelDocuments.Queries;
using Application.PassengerContext.TravelDocuments.Services;
using Application.PassengerContext.TravelDocuments.Validators;
using Application.SeatContext.Interfaces;
using Application.SeatContext.Queries;
using Application.SeatContext.Rules;
using Application.SeatContext.Services;
using Application.SeatContext.Validators;
using Core.Abstractions;
using Core.ActionHistoryContext.Interfaces;
using Core.BaggageContext.Interfaces;
using Core.FlightContext.Flights.Interfaces;
using Core.FlightContext.ReferenceData.Interfaces;
using Core.PassengerContext.Bookings.Interfaces;
using Core.PassengerContext.Comments.Interfaces;
using Core.PassengerContext.JoinClasses.Interfaces;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Interfaces;
using Core.PassengerContext.SpecialServiceRequests.Interfaces;
using Core.PassengerContext.TravelDocuments.Interfaces;
using Core.SeatContext.Interfaces;
using Core.TimeContext.Entities;
using Core.TimeContext.Interfaces;
using Infrastructure.Identity.Services;
using Infrastructure.Repositories;
using Infrastructure.Repositories.ActionHistoryRepositories;
using Infrastructure.Repositories.BaggageRepositories;
using Infrastructure.Repositories.CommentRepositories;
using Infrastructure.Repositories.FlightRepositories;
using Infrastructure.Repositories.PassengerRepositories;
using Infrastructure.Repositories.SeatRepositories;
using Infrastructure.Repositories.SpecialServiceRequestsRepositories;
using Infrastructure.Repositories.TravelDocumentRepositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Web.Errors;

namespace Web.Extensions;

/// <summary>
/// Provides extension methods for registering application services in the dependency injection container.
/// </summary>
public static class ApplicationsServicesExtensions
{
    /// <summary>
    /// Registers application services and configurations in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to which the services will be added.</param>
    /// <param name="config">The application configuration.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        var mongoConnectionString = config.GetConnectionString("MongoDB");
        var mongoUrl = new MongoUrl(mongoConnectionString);
        var databaseName = mongoUrl.DatabaseName;

        services.AddEndpointsApiExplorer();

        services.AddMemoryCache();
        //services.AddSingleton<ITimeProvider, SystemTimeProvider>();
        services.AddSingleton<ITimeProvider, TestTimeProvider>();
        services.AddSingleton<IMongoClient>(_ =>
            new MongoClient(mongoConnectionString));

        services.AddScoped<IActionHistoryRepository>(provider =>
            new ActionHistoryMongoRepository(
                provider.GetRequiredService<IMongoClient>(),
                databaseName
            )
        );

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBaggageRepository, BaggageRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<IOtherFlightRepository, OtherFlightRepository>();
        services.AddScoped<IBaseFlightRepository, BaseFlightRepository>();
        services.AddScoped<IPassengerRepository, PassengerRepository>();
        services.AddScoped<IInfantRepository, InfantRepository>();
        services.AddScoped<IDestinationRepository, DestinationRepository>();
        services.AddScoped<ISSRCodeRepository, SSRCodeRepository>();
        services.AddScoped<ISpecialServiceRequestRepository, SpecialServiceRequestRepository>();
        services.AddScoped<ITravelDocumentRepository, TravelDocumentRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IPredefinedCommentRepository, PredefinedCommentRepository>();
        services.AddScoped<IPassengerBookingDetailsRepository, PassengerBookingDetailsRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<IPassengerFlightRepository, PassengerFlightRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IBasePassengerOrItemRepository<BasePassengerOrItem>,
            BasePassengerOrItemRepository<BasePassengerOrItem>>();

        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IActionHistoryService, ActionHistoryService>();
        services.AddScoped<IPassengerOrItemDtoMappingService, PassengerOrItemDtoMappingService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IInfantService, InfantService>();
        services.AddScoped<IPassengerService, PassengerService>();
        services.AddScoped<IAcceptanceService, AcceptanceService>();
        services.AddScoped<ISeatAllocationService, SeatAllocationService>();
        services.AddScoped<INoRecPassengerService, NoRecPassengerService>();
        services.AddScoped<IFlightService, FlightService>();
        services.AddScoped<IAcceptanceService, AcceptanceService>();
        services.AddScoped<IActionHistoryService, ActionHistoryService>();
        services.AddScoped<IMappingService, MappingService>();
        services.AddScoped<IBaggageService, BaggageService>();
        services.AddScoped<ISeatService, SeatService>();
        services.AddScoped<ISpecialServiceRequestService, SpecialServiceRequestService>();
        services.AddScoped<ITravelDocumentService, TravelDocumentService>();

        services.AddScoped<IInfantValidator, InfantValidator>();
        services.AddScoped<IFlightQuery, FlightQuery>();
        services.AddScoped<ICheckinValidator, CheckInValidator>();
        services.AddScoped<INoRecPassengerValidator, NoRecPassengerValidator>();
        services.AddScoped<IAcceptanceValidator, AcceptanceValidator>();
        services.AddScoped<IBaggageValidator, BaggageValidator>();
        services.AddScoped<IFlightValidator, FlightValidator>();
        services.AddScoped<ISeatValidator, SeatValidator>();
        services.AddScoped<ISpecialServiceRequestValidator, SpecialServiceRequestValidator>();
        services.AddScoped<ITravelDocumentValidator, TravelDocumentValidator>();
        services.AddScoped<ICommentValidator, CommentValidator>();

        services.AddScoped<IBaggageFacade, BaggageFacade>();

        services.AddScoped<IBaggageQuery, BaggageQuery>();
        services.AddScoped<IPassengerQuery, PassengerQuery>();
        services.AddScoped<ISeatQuery, SeatQuery>();
        services.AddScoped<IDestinationQuery, DestinationQuery>();
        services.AddScoped<ICommentQuery, CommentQuery>();
        services.AddScoped<ISpecialServiceRequestQuery, SpecialServiceRequestQuery>();
        services.AddScoped<ISSRCodeQuery, SSRCodeQuery>();
        services.AddScoped<ICountryQuery, CountryQuery>();
        services.AddScoped<IPredefinedCommentQuery, PredefinedCommentQuery>();
        services.AddScoped<IBaseFlightQuery, BaseFlightQuery>();
        services.AddScoped<IBasePassengerOrItemQuery, BasePassengerOrItemQuery>();
        services.AddScoped<IInfantQuery, InfantQuery>();
        services.AddScoped<IOtherFlightQuery, OtherFlightQuery>();
        services.AddScoped<ITravelDocumentQuery, TravelDocumentQuery>();

        services.AddScoped<ICheckinRulesEvaluator, CheckinRulesEvaluator>();
        services.AddScoped<IFlightRulesEvaluator, FlightRulesEvaluator>();
        services.AddScoped<IBaggageRulesEvaluator, BaggageRulesEvaluator>();
        services.AddScoped<ISeatRulesEvaluator, SeatRulesEvaluator>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Where(e => e.Value is { Errors.Count: > 0 })
                    .SelectMany(x => x.Value != null ? x.Value.Errors : throw new InvalidOperationException())
                    .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse(errors);

                return new BadRequestObjectResult(errorResponse);
            };
        });

        return services;
    }
}