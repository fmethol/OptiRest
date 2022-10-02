using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiRest.Data.Migrations
{
    public partial class StandNombCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_countryId",
                table: "States");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "States",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "stateId",
                table: "States",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "States",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_States_countryId",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Countries",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "States",
                newName: "countryId");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "States",
                newName: "stateId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "States",
                newName: "state");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "States",
                newName: "IX_States_countryId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "countryId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "country");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_countryId",
                table: "States",
                column: "countryId",
                principalTable: "Countries",
                principalColumn: "countryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
