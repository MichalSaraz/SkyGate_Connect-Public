#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDateTimeOffsetcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewArrivalTimes",
                table: "ScheduledFlights",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewDepartureTimes",
                table: "ScheduledFlights",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NewArrivalDateTime",
                table: "Flights",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NewDepartureDateTime",
                table: "Flights",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 
                    new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewArrivalTimes",
                table: "ScheduledFlights");

            migrationBuilder.DropColumn(
                name: "NewDepartureTimes",
                table: "ScheduledFlights");

            migrationBuilder.DropColumn(
                name: "NewArrivalDateTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "NewDepartureDateTime",
                table: "Flights");
        }
    }
}
