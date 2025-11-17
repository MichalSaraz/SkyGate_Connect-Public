#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameNewDestinationFromandNewDestinationTocolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewDepartureDateTime",
                table: "Flights",
                newName: "UTCDepartureDateTime");

            migrationBuilder.RenameColumn(
                name: "NewArrivalDateTime",
                table: "Flights",
                newName: "UTCArrivalDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UTCDepartureDateTime",
                table: "Flights",
                newName: "NewDepartureDateTime");

            migrationBuilder.RenameColumn(
                name: "UTCArrivalDateTime",
                table: "Flights",
                newName: "NewArrivalDateTime");
        }
    }
}
