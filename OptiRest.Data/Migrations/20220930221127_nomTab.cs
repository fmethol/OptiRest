using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiRest.Data.Migrations
{
    public partial class nomTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_State_stateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_countryId",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_State_countryId",
                table: "States",
                newName: "IX_States_countryId");

            migrationBuilder.RenameIndex(
                name: "IX_City_stateId",
                table: "Cities",
                newName: "IX_Cities_stateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "stateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "countryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "cityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_stateId",
                table: "Cities",
                column: "stateId",
                principalTable: "States",
                principalColumn: "stateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_countryId",
                table: "States",
                column: "countryId",
                principalTable: "Countries",
                principalColumn: "countryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_stateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_countryId",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_States_countryId",
                table: "State",
                newName: "IX_State_countryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_stateId",
                table: "City",
                newName: "IX_City_stateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "stateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "countryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "cityId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_stateId",
                table: "City",
                column: "stateId",
                principalTable: "State",
                principalColumn: "stateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_countryId",
                table: "State",
                column: "countryId",
                principalTable: "Country",
                principalColumn: "countryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
