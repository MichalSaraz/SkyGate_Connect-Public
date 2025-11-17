#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameAPISDatatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APISData_Countries_CountryOfIssueId",
                table: "APISData");

            migrationBuilder.DropForeignKey(
                name: "FK_APISData_Countries_NationalityId",
                table: "APISData");

            migrationBuilder.DropForeignKey(
                name: "FK_APISData_Passengers_PassengerId",
                table: "APISData");

            migrationBuilder.RenameTable(
                name: "APISData",
                newName: "TravelDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_APISData_PassengerId",
                table: "TravelDocuments",
                newName: "IX_TravelDocuments_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_APISData_NationalityId",
                table: "TravelDocuments",
                newName: "IX_TravelDocuments_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_APISData_CountryOfIssueId",
                table: "TravelDocuments",
                newName: "IX_TravelDocuments_CountryOfIssueId");

            migrationBuilder.DropPrimaryKey(
                name: "PK_APISData",
                table: "TravelDocuments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelDocuments",
                table: "TravelDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelDocuments_Countries_CountryOfIssueId",
                table: "TravelDocuments",
                column: "CountryOfIssueId",
                principalTable: "Countries",
                principalColumn: "Country2LetterCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelDocuments_Countries_NationalityId",
                table: "TravelDocuments",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Country2LetterCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelDocuments_Passengers_PassengerId",
                table: "TravelDocuments",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelDocuments_Countries_CountryOfIssueId",
                table: "TravelDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelDocuments_Countries_NationalityId",
                table: "TravelDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelDocuments_Passengers_PassengerId",
                table: "TravelDocuments");

            // přejmenujeme tabulku zpět
            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelDocuments",
                table: "TravelDocuments");

            migrationBuilder.RenameTable(
                name: "TravelDocuments",
                newName: "APISData");

            // přejmenujeme indexy zpět
            migrationBuilder.RenameIndex(
                name: "IX_TravelDocuments_PassengerId",
                table: "APISData",
                newName: "IX_APISData_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelDocuments_NationalityId",
                table: "APISData",
                newName: "IX_APISData_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelDocuments_CountryOfIssueId",
                table: "APISData",
                newName: "IX_APISData_CountryOfIssueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APISData",
                table: "APISData",
                column: "Id");

            // obnovíme původní FK
            migrationBuilder.AddForeignKey(
                name: "FK_APISData_Countries_CountryOfIssueId",
                table: "APISData",
                column: "CountryOfIssueId",
                principalTable: "Countries",
                principalColumn: "Country2LetterCode");

            migrationBuilder.AddForeignKey(
                name: "FK_APISData_Countries_NationalityId",
                table: "APISData",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Country2LetterCode");

            migrationBuilder.AddForeignKey(
                name: "FK_APISData_Passengers_PassengerId",
                table: "APISData",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
