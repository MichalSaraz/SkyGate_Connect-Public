.
├── .env
├── .env.example
├── .gitattributes
├── .gitignore
├── AppTest
│   ├── Api
│   │   ├── AccountManagement
│   │   │   └── Controllers
│   │   │       └── AccountControllerTest.cs
│   │   └── BaggageManagement
│   │       └── Controllers
│   │           └── BaggageControllerTest.cs
│   ├── TestProject.csproj
│   └── Usings.cs
├── Application
│   ├── ActionHistoryContext
│   │   ├── Interfaces
│   │   │   └── IActionHistoryService.cs
│   │   └── Services
│   │       └── ActionHistoryService.cs
│   ├── Application.csproj
│   ├── BaggageContext
│   │   ├── Commands
│   │   │   ├── CreateBaggageCommand.cs
│   │   │   └── EditBaggageCommand.cs
│   │   ├── Expressions
│   │   │   └── BaggageCriteria.cs
│   │   ├── Facades
│   │   │   └── BaggageFacade.cs
│   │   ├── Interfaces
│   │   │   ├── IBaggageFacade.cs
│   │   │   ├── IBaggageQuery.cs
│   │   │   ├── IBaggageRulesEvaluator.cs
│   │   │   ├── IBaggageService.cs
│   │   │   └── IBaggageValidator.cs
│   │   ├── Logging
│   │   │   ├── BaggageFacadeLog.cs
│   │   │   ├── BaggageServiceLog.cs
│   │   │   └── BaggageValidatorLog.cs
│   │   ├── Queries
│   │   │   └── BaggageQuery.cs
│   │   ├── Rules
│   │   │   └── BaggageRulesEvaluator.cs
│   │   ├── Services
│   │   │   └── BaggageService.cs
│   │   └── Validators
│   │       └── BaggageValidator.cs
│   ├── FlightContext
│   │   ├── Expressions
│   │   │   └── FlightCriteria.cs
│   │   ├── Interfaces
│   │   │   ├── IBaseFlightQuery.cs
│   │   │   ├── IDestinationQuery.cs
│   │   │   ├── IFlightQuery.cs
│   │   │   ├── IFlightRulesEvaluator.cs
│   │   │   ├── IFlightService.cs
│   │   │   ├── IFlightValidator.cs
│   │   │   └── IOtherFlightQuery.cs
│   │   ├── Params
│   │   │   ├── AddConnectingFlightParam.cs
│   │   │   └── FlightSearchParam.cs
│   │   ├── Queries
│   │   │   ├── BaseFlightQuery.cs
│   │   │   ├── DestinationQuery.cs
│   │   │   ├── FlightQuery.cs
│   │   │   └── OtherFlightQuery.cs
│   │   ├── Results
│   │   │   └── ConnectedFlightsResult.cs
│   │   ├── Rules
│   │   │   └── FlightRulesEvaluator.cs
│   │   ├── Services
│   │   │   └── FlightService.cs
│   │   └── Validators
│   │       └── FlightValidator.cs
│   ├── Identity
│   │   └── Interfaces
│   │       └── ITokenService.cs
│   ├── MappingContext
│   │   ├── Interfaces
│   │   │   ├── IMappingService.cs
│   │   │   └── IPassengerOrItemDtoMappingService.cs
│   │   └── Services
│   │       ├── MappingService.cs
│   │       └── PassengerOrItemDtoMappingService.cs
│   ├── PassengerContext
│   │   ├── Comments
│   │   │   ├── Expressions
│   │   │   │   └── CommentCriteria.cs
│   │   │   ├── Interfaces
│   │   │   │   ├── ICommentQuery.cs
│   │   │   │   ├── ICommentService.cs
│   │   │   │   ├── ICommentValidator.cs
│   │   │   │   └── IPredefinedCommentQuery.cs
│   │   │   ├── Queries
│   │   │   │   ├── CommentQuery.cs
│   │   │   │   └── PredefinedCommentQuery.cs
│   │   │   ├── Services
│   │   │   │   └── CommentService.cs
│   │   │   └── Validators
│   │   │       └── CommentValidator.cs
│   │   ├── Passengers
│   │   │   ├── Commands
│   │   │   │   ├── CreateInfantCommand.cs
│   │   │   │   └── CreatePassengerCommand.cs
│   │   │   ├── Expressions
│   │   │   │   └── PassengerCriteria.cs
│   │   │   ├── Interfaces
│   │   │   │   ├── IAcceptanceService.cs
│   │   │   │   ├── IAcceptanceValidator.cs
│   │   │   │   ├── IBasePassengerOrItemQuery.cs
│   │   │   │   ├── ICheckinRulesEvaluator.cs
│   │   │   │   ├── ICheckinValidator.cs
│   │   │   │   ├── IInfantQuery.cs
│   │   │   │   ├── IInfantService.cs
│   │   │   │   ├── IInfantValidator.cs
│   │   │   │   ├── INoRecPassengerService.cs
│   │   │   │   ├── INoRecPassengerValidator.cs
│   │   │   │   ├── IPassengerQuery.cs
│   │   │   │   └── IPassengerService.cs
│   │   │   ├── Params
│   │   │   │   └── PassengerSearchParam.cs
│   │   │   ├── Queries
│   │   │   │   ├── BasePassengerOrItemQuery.cs
│   │   │   │   ├── InfantQuery.cs
│   │   │   │   └── PassengerQuery.cs
│   │   │   ├── Requests
│   │   │   │   └── PassengerCheckinRequest.cs
│   │   │   ├── Results
│   │   │   │   ├── AddInfantValidationResult.cs
│   │   │   │   ├── CheckinValidationResult.cs
│   │   │   │   ├── PassengerSelectionResult.cs
│   │   │   │   └── RemoveInfantValidationResult.cs
│   │   │   ├── Rules
│   │   │   │   └── CheckinRulesEvaluator.cs
│   │   │   ├── Services
│   │   │   │   ├── AcceptanceService.cs
│   │   │   │   ├── InfantService.cs
│   │   │   │   ├── NoRecPassengerService.cs
│   │   │   │   └── PassengerService.cs
│   │   │   └── Validators
│   │   │       ├── AcceptanceValidator.cs
│   │   │       ├── CheckInValidator.cs
│   │   │       ├── InfantValidator.cs
│   │   │       └── NoRecPassengerValidator.cs
│   │   ├── SpecialServiceRequests
│   │   │   ├── Interfaces
│   │   │   │   ├── ISSRCodeQuery.cs
│   │   │   │   ├── ISpecialServiceRequestQuery.cs
│   │   │   │   ├── ISpecialServiceRequestService.cs
│   │   │   │   └── ISpecialServiceRequestValidator.cs
│   │   │   ├── Queries
│   │   │   │   ├── SSRCodeQuery.cs
│   │   │   │   └── SpecialServiceRequestQuery.cs
│   │   │   ├── Services
│   │   │   │   └── SpecialServiceRequestService.cs
│   │   │   └── Validators
│   │   │       └── SpecialServiceRequestValidator.cs
│   │   └── TravelDocuments
│   │       ├── Commands
│   │       │   ├── CreateTravelDocumentCommand.cs
│   │       │   └── EditTravelDocumentCommand.cs
│   │       ├── Interfaces
│   │       │   ├── ICountryQuery.cs
│   │       │   ├── ITravelDocumentQuery.cs
│   │       │   ├── ITravelDocumentService.cs
│   │       │   └── ITravelDocumentValidator.cs
│   │       ├── Queries
│   │       │   ├── CountryQuery.cs
│   │       │   └── TravelDocumentQuery.cs
│   │       ├── Services
│   │       │   └── TravelDocumentService.cs
│   │       └── Validators
│   │           └── TravelDocumentValidator.cs
│   ├── SeatContext
│   │   ├── Expressions
│   │   │   └── SeatCriteria.cs
│   │   ├── Interfaces
│   │   │   ├── ISeatAllocationService.cs
│   │   │   ├── ISeatQuery.cs
│   │   │   ├── ISeatRulesEvaluator.cs
│   │   │   ├── ISeatService.cs
│   │   │   └── ISeatValidator.cs
│   │   ├── Queries
│   │   │   └── SeatQuery.cs
│   │   ├── Results
│   │   │   ├── AssignSeatsAndClassesResult.cs
│   │   │   └── PrepareSeatsForChangeResult.cs
│   │   ├── Rules
│   │   │   └── SeatRulesEvaluator.cs
│   │   ├── Services
│   │   │   ├── SeatAllocationService.cs
│   │   │   └── SeatService.cs
│   │   ├── Strategies
│   │   │   └── SeatSelectionStrategy.cs
│   │   └── Validators
│   │       └── SeatValidator.cs
│   └── _Common
│       └── QueryBase.cs
├── Core
│   ├── Abstractions
│   │   └── IGenericRepository.cs
│   ├── ActionHistoryContext
│   │   ├── Entities
│   │   │   ├── ActionHistoryDocument.cs
│   │   │   └── ActionHistoryScope.cs
│   │   ├── Enums
│   │   │   └── ActionTypeEnum.cs
│   │   └── Interfaces
│   │       ├── IActionHistoryRepository.cs
│   │       └── IActionHistoryScope.cs
│   ├── BaggageContext
│   │   ├── Dtos
│   │   │   ├── BaggageBaseDto.cs
│   │   │   ├── BaggageDetailsDto.cs
│   │   │   └── BaggageOverviewDto.cs
│   │   ├── Entities
│   │   │   ├── Baggage.cs
│   │   │   ├── BaggageTag.cs
│   │   │   └── SpecialBag.cs
│   │   ├── Enums
│   │   │   ├── BaggageTypeEnum.cs
│   │   │   ├── SpecialBagEnum.cs
│   │   │   └── TagTypeEnum.cs
│   │   └── Interfaces
│   │       └── IBaggageRepository.cs
│   ├── Core.csproj
│   ├── FlightContext
│   │   ├── Flights
│   │   │   ├── Dtos
│   │   │   │   ├── BoardingDto.cs
│   │   │   │   ├── FlightConnectionsDto.cs
│   │   │   │   ├── FlightDetailsDto.cs
│   │   │   │   └── FlightOverviewDto.cs
│   │   │   ├── Entities
│   │   │   │   ├── BaseFlight.cs
│   │   │   │   ├── Flight.cs
│   │   │   │   ├── OtherFlight.cs
│   │   │   │   └── ScheduledFlight.cs
│   │   │   ├── Enums
│   │   │   │   ├── BoardingStatusEnum.cs
│   │   │   │   └── FlightStatusEnum.cs
│   │   │   └── Interfaces
│   │   │       ├── IBaseFlightRepository.cs
│   │   │       ├── IFlightRepository.cs
│   │   │       └── IOtherFlightRepository.cs
│   │   ├── JoinClasses
│   │   │   ├── Dtos
│   │   │   │   ├── FlightBaggageDto.cs
│   │   │   │   └── FlightCommentDto.cs
│   │   │   └── Entities
│   │   │       ├── FlightBaggage.cs
│   │   │       └── FlightComment.cs
│   │   └── ReferenceData
│   │       ├── Entities
│   │       │   ├── Aircraft.cs
│   │       │   ├── AircraftType.cs
│   │       │   ├── Airline.cs
│   │       │   └── Destination.cs
│   │       └── Interfaces
│   │           └── IDestinationRepository.cs
│   ├── Identity
│   │   ├── Dtos
│   │   │   └── UserDto.cs
│   │   ├── Entities
│   │   │   └── AppUser.cs
│   │   └── Enums
│   │       └── RoleEnum.cs
│   ├── OperationResults
│   │   ├── ErrorResult.cs
│   │   ├── NoDataResponse.cs
│   │   ├── Result.cs
│   │   ├── ResultExtension.cs
│   │   └── SuccessResult.cs
│   ├── PassengerContext
│   │   ├── Bookings
│   │   │   ├── Entities
│   │   │   │   ├── BookingReference.cs
│   │   │   │   ├── FrequentFlyer.cs
│   │   │   │   └── PassengerBookingDetails.cs
│   │   │   ├── Enums
│   │   │   │   └── TierLevelEnum.cs
│   │   │   └── Interfaces
│   │   │       └── IPassengerBookingDetailsRepository.cs
│   │   ├── Comments
│   │   │   ├── Dtos
│   │   │   │   └── CommentDto.cs
│   │   │   ├── Entities
│   │   │   │   ├── Comment.cs
│   │   │   │   └── PreDefinedComment.cs
│   │   │   ├── Enums
│   │   │   │   ├── CommentTypeEnum.cs
│   │   │   │   └── PredefinedCommentEnum.cs
│   │   │   └── Interfaces
│   │   │       ├── ICommentRepository.cs
│   │   │       └── IPredefinedCommentRepository.cs
│   │   ├── JoinClasses
│   │   │   ├── Dtos
│   │   │   │   ├── PassengerFlightConnectionsDto.cs
│   │   │   │   ├── PassengerFlightDto.cs
│   │   │   │   ├── PassengerOrItemCommentsDto.cs
│   │   │   │   └── PassengerSpecialServiceRequestsDto.cs
│   │   │   ├── Entities
│   │   │   │   └── PassengerFlight.cs
│   │   │   └── Interfaces
│   │   │       └── IPassengerFlightRepository.cs
│   │   ├── Passengers
│   │   │   ├── Dtos
│   │   │   │   ├── BasePassengerOrItemDto.cs
│   │   │   │   ├── InfantDetailsDto.cs
│   │   │   │   ├── InfantOverviewDto.cs
│   │   │   │   ├── InfantResponseDto.cs
│   │   │   │   ├── ItemDetailsDto.cs
│   │   │   │   ├── PassengerDetailsDto.cs
│   │   │   │   └── PassengerOrItemOverviewDto.cs
│   │   │   ├── Entities
│   │   │   │   ├── BasePassengerOrItem.cs
│   │   │   │   ├── CabinBaggageRequiringSeat.cs
│   │   │   │   ├── ExtraSeat.cs
│   │   │   │   ├── Infant.cs
│   │   │   │   └── Passenger.cs
│   │   │   ├── Enums
│   │   │   │   ├── AcceptanceStatusEnum.cs
│   │   │   │   ├── NotTravellingReasonEnum.cs
│   │   │   │   └── PaxGenderEnum.cs
│   │   │   └── Interfaces
│   │   │       ├── IBasePassengerOrItemRepository.cs
│   │   │       ├── IInfantRepository.cs
│   │   │       ├── IItemRepository.cs
│   │   │       └── IPassengerRepository.cs
│   │   ├── SpecialServiceRequests
│   │   │   ├── Dtos
│   │   │   │   └── SpecialServiceRequestDto.cs
│   │   │   ├── Entities
│   │   │   │   ├── SSRCode.cs
│   │   │   │   └── SpecialServiceRequest.cs
│   │   │   └── Interfaces
│   │   │       ├── ISSRCodeRepository.cs
│   │   │       └── ISpecialServiceRequestRepository.cs
│   │   └── TravelDocuments
│   │       ├── Dtos
│   │       │   └── TravelDocumentDto.cs
│   │       ├── Entities
│   │       │   ├── Country.cs
│   │       │   └── TravelDocument.cs
│   │       ├── Enums
│   │       │   └── DocumentTypeEnum.cs
│   │       └── Interfaces
│   │           ├── ICountryRepository.cs
│   │           └── ITravelDocumentRepository.cs
│   ├── SeatContext
│   │   ├── Dtos
│   │   │   └── SeatDto.cs
│   │   ├── Entities
│   │   │   ├── FlightClassSpecification.cs
│   │   │   ├── Seat.cs
│   │   │   └── SeatMap.cs
│   │   ├── Enums
│   │   │   ├── BoardingZoneEnum.cs
│   │   │   ├── FlightClassEnum.cs
│   │   │   ├── SeatLetterEnum.cs
│   │   │   ├── SeatPositionEnum.cs
│   │   │   ├── SeatPreferenceEnum.cs
│   │   │   ├── SeatStatusEnum.cs
│   │   │   └── SeatTypeEnum.cs
│   │   └── Interfaces
│   │       └── ISeatRepository.cs
│   └── TimeContext
│       ├── Entities
│       │   ├── SystemTimeProvider.cs
│       │   ├── TestTimeProvider.cs
│       │   └── TimeProviderBase.cs
│       └── Interfaces
│           └── ITimeProvider.cs
├── Dockerfile
├── Infrastructure
│   ├── Data
│   │   ├── AppDbContext.cs
│   │   ├── AppDbSeedData.cs
│   │   ├── Config
│   │   │   ├── BaggageConfig
│   │   │   │   └── BaggageConfig.cs
│   │   │   ├── FlightConfig
│   │   │   │   ├── AircraftConfig.cs
│   │   │   │   ├── AirlineConfig.cs
│   │   │   │   ├── BaseFlightConfig.cs
│   │   │   │   ├── DestinationConfig.cs
│   │   │   │   ├── FlightConfig.cs
│   │   │   │   ├── OtherFlightConfig.cs
│   │   │   │   └── ScheduledFlightConfig.cs
│   │   │   ├── JoinClassesConfig
│   │   │   │   ├── FlightBaggageConfig.cs
│   │   │   │   ├── FlightCommentConfig.cs
│   │   │   │   ├── PassengerFlightConfig.cs
│   │   │   │   └── SpecialServiceRequestConfig.cs
│   │   │   ├── PassengerConfig
│   │   │   │   ├── BasePassengerOrItemConfig.cs
│   │   │   │   ├── BookingConfig
│   │   │   │   │   ├── BookingReferenceConfig.cs
│   │   │   │   │   ├── FrequentFlyerConfig.cs
│   │   │   │   │   └── PassengerBookingDetailsConfig.cs
│   │   │   │   ├── CommentConfig
│   │   │   │   │   ├── CommentConfig.cs
│   │   │   │   │   └── PredefinedCommentConfig.cs
│   │   │   │   ├── InfantConfig.cs
│   │   │   │   ├── PassengerConfig.cs
│   │   │   │   └── TravelDocumentConfig
│   │   │   │       └── TravelDocumentConfig.cs
│   │   │   └── SeatConfig
│   │   │       ├── SeatConfig.cs
│   │   │       └── SeatMapConfig.cs
│   │   ├── SeedData
│   │   │   ├── AircraftTypes.json
│   │   │   ├── Aircrafts.json
│   │   │   ├── Airlines.json
│   │   │   ├── Countries.json
│   │   │   ├── Destinations.json
│   │   │   ├── ScheduledFlights.json
│   │   │   └── SeatMaps.json
│   │   └── ValueConversion
│   │       ├── Comparers
│   │       │   ├── DateTimeOffsetKeyValuePairJsonConverter.cs
│   │       │   ├── DateTimeOffsetKeyValuePairListComparer.cs
│   │       │   ├── DictionaryValueComparer.cs
│   │       │   ├── ListValueComparer.cs
│   │       │   └── TimeSpanKeyValuePairJsonConverter.cs
│   │       ├── Converters
│   │       │   ├── DateTimeConverter.cs
│   │       │   ├── DateTimeOffsetConverter.cs
│   │       │   ├── EnumConverter.cs
│   │       │   └── JsonValueConverter.cs
│   │       └── ValueConversionExtensions.cs
│   ├── Identity
│   │   ├── AppIdentityDbContext.cs
│   │   ├── AppIdentityDbContextSeed.cs
│   │   ├── Migrations
│   │   │   ├── 20240715165424_IdentityInitial.Designer.cs
│   │   │   ├── 20240715165424_IdentityInitial.cs
│   │   │   ├── 20240717193606_Add_Roles_and_Station_property.Designer.cs
│   │   │   ├── 20240717193606_Add_Roles_and_Station_property.cs
│   │   │   └── AppIdentityDbContextModelSnapshot.cs
│   │   └── Services
│   │       ├── Logging
│   │       │   └── TokenServiceLog.cs
│   │       └── TokenService.cs
│   ├── Infrastructure.csproj
│   ├── Migrations
│   │   ├── 20240628171656_InitialMigration.Designer.cs
│   │   ├── 20240628171656_InitialMigration.cs
│   │   ├── 20240629142159_add_trackable_entity.Designer.cs
│   │   ├── 20240629142159_add_trackable_entity.cs
│   │   ├── 20240629214848_add_ActionHistory.Designer.cs
│   │   ├── 20240629214848_add_ActionHistory.cs
│   │   ├── 20240630101104_change_Timezone.Designer.cs
│   │   ├── 20240630101104_change_Timezone.cs
│   │   ├── 20240630151941_add_Type_column.Designer.cs
│   │   ├── 20240630151941_add_Type_column.cs
│   │   ├── 20240712185147_notTravellingReason.Designer.cs
│   │   ├── 20240712185147_notTravellingReason.cs
│   │   ├── 20240712195911_notTravellingReason2.Designer.cs
│   │   ├── 20240712195911_notTravellingReason2.cs
│   │   ├── 20250125140603_add IanaTimeZone column.Designer.cs
│   │   ├── 20250125140603_add IanaTimeZone column.cs
│   │   ├── 20250125173114_add DateTimeOffset columns.Designer.cs
│   │   ├── 20250125173114_add DateTimeOffset columns.cs
│   │   ├── 20250125201307_rename NewDestinationFrom and NewDestinationTo columns.Designer.cs
│   │   ├── 20250125201307_rename NewDestinationFrom and NewDestinationTo columns.cs
│   │   ├── 20250125233601_rename ScheduledFlight properties.Designer.cs
│   │   ├── 20250125233601_rename ScheduledFlight properties.cs
│   │   ├── 20251022211506_CleanupAndFixEnums.Designer.cs
│   │   ├── 20251022211506_CleanupAndFixEnums.cs
│   │   ├── 20251104194924_rename APISData table.Designer.cs
│   │   ├── 20251104194924_rename APISData table.cs
│   │   ├── 20251115142336_RemoveSsrId.Designer.cs
│   │   ├── 20251115142336_RemoveSsrId.cs
│   │   └── AppDbContextModelSnapshot.cs
│   └── Repositories
│       ├── ActionHistoryRepositories
│       │   └── ActionHistoryMongoRepository.cs
│       ├── BaggageRepositories
│       │   ├── BaggageRepository.cs
│       │   └── Logging
│       │       └── BaggageRepositoryLog.cs
│       ├── CommentRepositories
│       │   ├── CommentRepository.cs
│       │   └── PredefinedCommentRepository.cs
│       ├── FlightRepositories
│       │   ├── BaseFlightRepository.cs
│       │   ├── DestinationRepository.cs
│       │   ├── FlightRepository.cs
│       │   └── OtherFlightRepository.cs
│       ├── GenericRepository.cs
│       ├── PassengerBookingDetailsRepository.cs
│       ├── PassengerFlightRepository.cs
│       ├── PassengerRepositories
│       │   ├── BasePassengerOrItemRepository.cs
│       │   ├── InfantRepository.cs
│       │   ├── ItemRepository.cs
│       │   └── PassengerRepository.cs
│       ├── SeatRepositories
│       │   └── SeatRepository.cs
│       ├── SpecialServiceRequestsRepositories
│       │   ├── SSRCodeRepository.cs
│       │   └── SpecialServiceRequestRepository.cs
│       └── TravelDocumentRepositories
│           ├── CountryRepository.cs
│           └── TravelDocumentRepository.cs
├── PROJECT_TREE.md
├── README.md
├── Shared
│   ├── Exceptions
│   └── Shared.csproj
├── SkyGate_Connect.sln
├── SkyGate_Connect.sln.DotSettings
├── SkyGate_Connect.sln.DotSettings.user
├── Web
│   ├── Api
│   │   ├── AccountManagement
│   │   │   ├── Controllers
│   │   │   │   └── AccountController.cs
│   │   │   ├── Logging
│   │   │   │   └── AccountControllerLog.cs
│   │   │   └── Models
│   │   │       ├── LoginModel.cs
│   │   │       └── RegisterModel.cs
│   │   ├── BaggageManagement
│   │   │   ├── Controllers
│   │   │   │   └── BaggageController.cs
│   │   │   ├── Logging
│   │   │   │   └── BaggageControllerLog.cs
│   │   │   └── Models
│   │   │       ├── AddBaggageModel.cs
│   │   │       └── EditBaggageModel.cs
│   │   ├── FlightManagement
│   │   │   ├── Controllers
│   │   │   │   └── FlightController.cs
│   │   │   ├── Logging
│   │   │   └── Models
│   │   │       ├── AddConnectingFlightModel.cs
│   │   │       └── FlightSearchModel.cs
│   │   ├── PassengerManagement
│   │   │   ├── Controllers
│   │   │   │   ├── CommentController.cs
│   │   │   │   ├── PassengerController.cs
│   │   │   │   ├── SpecialServiceRequestController.cs
│   │   │   │   └── TravelDocumentController.cs
│   │   │   ├── Logging
│   │   │   └── Models
│   │   │       ├── AddCommentModel.cs
│   │   │       ├── AddTravelDocumentModel.cs
│   │   │       ├── BoardPassengerModel.cs
│   │   │       ├── EditTravelDocumentModel.cs
│   │   │       ├── InfantModel.cs
│   │   │       ├── NoRecPassengerModel.cs
│   │   │       ├── PassengerCheckInModel.cs
│   │   │       ├── PassengerOffloadModel.cs
│   │   │       ├── PassengerSearchModel.cs
│   │   │       ├── PassengerSelectionUpdateModel.cs
│   │   │       ├── SSRCodeModel.cs
│   │   │       ├── SpecialServiceRequestModel.cs
│   │   │       └── TravelDocumentModel.cs
│   │   └── SeatManagement
│   │       ├── Controllers
│   │       │   └── SeatController.cs
│   │       └── Logging
│   ├── Errors
│   │   ├── ApiException.cs
│   │   ├── ApiResponse.cs
│   │   └── ApiValidationErrorResponse.cs
│   ├── Extensions
│   │   ├── ActionResultExtension.cs
│   │   ├── ApplicationsServicesExtensions.cs
│   │   ├── ExpressionExtensions.cs
│   │   └── IdentityServiceExtensions.cs
│   ├── Helpers
│   │   ├── Mappings
│   │   │   ├── BaggageMappings.cs
│   │   │   ├── BasePassengerOrItemMappings.cs
│   │   │   ├── CommentMappings.cs
│   │   │   ├── FlightMappings.cs
│   │   │   ├── JoinClassesMappings.cs
│   │   │   ├── SeatMappings.cs
│   │   │   ├── SpecialServiceRequestMappings.cs
│   │   │   └── TravelDocumentMappings.cs
│   │   └── ParameterRebinder.cs
│   ├── Middleware
│   │   └── ExceptionMiddleware.cs
│   ├── Program.cs
│   ├── Properties
│   │   ├── launchSettings.json
│   │   ├── serviceDependencies.json
│   │   └── serviceDependencies.local.json
│   ├── Web.csproj
│   ├── appsettings.Development.json
│   └── appsettings.json
├── docker-compose.yml
├── global.json
├── package-lock.json
└── package.json

197 directories, 402 files
