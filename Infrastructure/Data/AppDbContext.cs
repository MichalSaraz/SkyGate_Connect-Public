using System.Reflection;
using Core.BaggageContext.Entities;
using Core.FlightContext.Flights.Entities;
using Core.FlightContext.JoinClasses.Entities;
using Core.FlightContext.ReferenceData.Entities;
using Core.PassengerContext.Bookings.Entities;
using Core.PassengerContext.Comments.Entities;
using Core.PassengerContext.JoinClasses.Entities;
using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.SpecialServiceRequests.Entities;
using Core.PassengerContext.TravelDocuments.Entities;
using Core.SeatContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;

/// <summary>
/// Represents the application's database context, which is used to interact with the database.
/// This class is derived from <see cref="DbContext"/> and provides <see cref="DbSet{TEntity}"/> properties
/// for each entity in the application.
/// </summary>
public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    /// <summary>
    /// Gets or sets the database set for scheduled flights.
    /// </summary>
    public DbSet<ScheduledFlight> ScheduledFlights { get; set; }

    /// <summary>
    /// Gets or sets the database set for flights.
    /// </summary>
    public DbSet<BaseFlight> Flights { get; set; }

    /// <summary>
    /// Gets or sets the database set for passengers or items.
    /// </summary>
    public DbSet<BasePassengerOrItem> Passengers { get; set; }

    /// <summary>
    /// Gets or sets the database set for passenger flights.
    /// </summary>
    public DbSet<PassengerFlight> PassengerFlight { get; set; }

    /// <summary>
    /// Gets or sets the database set for passenger booking details.
    /// </summary>
    public DbSet<PassengerBookingDetails> PassengerBookingDetails { get; set; }

    /// <summary>
    /// Gets or sets the database set for baggage.
    /// </summary>
    public DbSet<Baggage> Baggage { get; set; }

    /// <summary>
    /// Gets or sets the database set for aircraft.
    /// </summary>
    public DbSet<Aircraft> Aircrafts { get; set; }

    /// <summary>
    /// Gets or sets the database set for seats.
    /// </summary>
    public DbSet<Seat> Seats { get; set; }

    /// <summary>
    /// Gets or sets the database set for special service requests.
    /// </summary>
    public DbSet<SpecialServiceRequest> SpecialServiceRequests { get; set; }

    /// <summary>
    /// Gets or sets the database set for aircraft types.
    /// </summary>
    public DbSet<AircraftType> AircraftTypes { get; set; }

    /// <summary>
    /// Gets or sets the database set for airlines.
    /// </summary>
    public DbSet<Airline> Airlines { get; set; }

    /// <summary>
    /// Gets or sets the database set for destinations.
    /// </summary>
    public DbSet<Destination> Destinations { get; set; }

    /// <summary>
    /// Gets or sets the database set for booking references.
    /// </summary>
    public DbSet<BookingReference> BookingReferences { get; set; }

    /// <summary>
    /// Gets or sets the database set for comments.
    /// </summary>
    public DbSet<Comment> Comments { get; set; }

    /// <summary>
    /// Gets or sets the database set for flight comments.
    /// </summary>
    public DbSet<FlightComment> FlightComment { get; set; }

    /// <summary>
    /// Gets or sets the database set for flight baggage.
    /// </summary>
    public DbSet<FlightBaggage> FlightBaggage { get; set; }

    /// <summary>
    /// Gets or sets the database set for predefined comments.
    /// </summary>
    public DbSet<PredefinedComment> PredefinedComments { get; set; }

    /// <summary>
    /// Gets or sets the database set for frequent flyer cards.
    /// </summary>
    public DbSet<FrequentFlyer> FrequentFlyerCards { get; set; }

    /// <summary>
    /// Gets or sets the database set for SSR codes.
    /// </summary>
    public DbSet<SSRCode> SSRCodes { get; set; }

    /// <summary>
    /// Gets or sets the database set for travel documents.
    /// </summary>
    public DbSet<TravelDocument> TravelDocuments { get; set; }

    /// <summary>
    /// Gets or sets the database set for countries.
    /// </summary>
    public DbSet<Country> Countries { get; set; }

    /// <summary>
    /// Gets or sets the database set for seat maps.
    /// </summary>
    public DbSet<SeatMap> SeatMaps { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Configures the database connection using the specified options builder.
    /// </summary>
    /// <param name="options">The options builder to configure the database connection.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    /// <summary>
    /// Configures the model using the specified model builder.
    /// </summary>
    /// <param name="modelBuilder">The model builder to configure the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.HasSequence<int>("BaggageTagsSequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMax(999999)
            .IsCyclic();
    }
}