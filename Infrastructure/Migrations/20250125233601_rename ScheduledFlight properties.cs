#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameScheduledFlightproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewDepartureTimes",
                table: "ScheduledFlights",
                newName: "DepartureTimesInUTCTime");

            migrationBuilder.RenameColumn(
                name: "NewArrivalTimes",
                table: "ScheduledFlights",
                newName: "ArrivalTimesInUTCTime");

            migrationBuilder.RenameColumn(
                name: "DepartureTimes",
                table: "ScheduledFlights",
                newName: "DepartureTimesInLocalTime");
            
            migrationBuilder.RenameColumn(
                name: "ArrivalTimes",
                table: "ScheduledFlights",
                newName: "ArrivalTimesInLocalTime");
            
            migrationBuilder.RenameColumn(
                name: "DestinationTo",
                table: "ScheduledFlights",
                newName: "DestinationToId");

            migrationBuilder.RenameColumn(
                name: "DestinationFrom",
                table: "ScheduledFlights",
                newName: "DestinationFromId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledFlights_DestinationFromId",
                table: "ScheduledFlights",
                column: "DestinationFromId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledFlights_DestinationToId",
                table: "ScheduledFlights",
                column: "DestinationToId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledFlights_Destinations_DestinationFromId",
                table: "ScheduledFlights",
                column: "DestinationFromId",
                principalTable: "Destinations",
                principalColumn: "IATAAirportCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledFlights_Destinations_DestinationToId",
                table: "ScheduledFlights",
                column: "DestinationToId",
                principalTable: "Destinations",
                principalColumn: "IATAAirportCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledFlights_Destinations_DestinationFromId",
                table: "ScheduledFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledFlights_Destinations_DestinationToId",
                table: "ScheduledFlights");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledFlights_DestinationFromId",
                table: "ScheduledFlights");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledFlights_DestinationToId",
                table: "ScheduledFlights");
            
            migrationBuilder.RenameColumn(
                name: "DestinationToId",
                table: "ScheduledFlights",
                newName: "DestinationTo");

            migrationBuilder.RenameColumn(
                name: "DestinationFromId",
                table: "ScheduledFlights",
                newName: "DestinationFrom");

            migrationBuilder.RenameColumn(
                name: "DepartureTimesInUTCTime",
                table: "ScheduledFlights",
                newName: "NewDepartureTimes");

            migrationBuilder.RenameColumn(
                name: "DepartureTimesInLocalTime",
                table: "ScheduledFlights",
                newName: "DepartureTimes");

            migrationBuilder.RenameColumn(
                name: "ArrivalTimesInUTCTime",
                table: "ScheduledFlights",
                newName: "NewArrivalTimes");

            migrationBuilder.RenameColumn(
                name: "ArrivalTimesInLocalTime",
                table: "ScheduledFlights",
                newName: "ArrivalTimes");
        }
    }
}
