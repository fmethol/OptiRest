using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiRest.Data.Migrations
{
    public partial class Cities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_countryId",
                table: "State");

            migrationBuilder.AlterColumn<int>(
                name: "countryId",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    cityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.cityId);
                    table.ForeignKey(
                        name: "FK_City_State_stateId",
                        column: x => x.stateId,
                        principalTable: "State",
                        principalColumn: "stateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "stateId", "countryId", "state" },
                values: new object[,]
                {
                    { 1, 1, "Buenos Aires" },
                    { 2, 1, "Catamarca" },
                    { 3, 1, "Chaco" },
                    { 4, 1, "Chubut" },
                    { 5, 1, "Ciudad Autónoma de Buenos Aires" },
                    { 6, 1, "Córdoba" },
                    { 7, 1, "Corrientes" },
                    { 8, 1, "Entre Ríos" },
                    { 9, 1, "Formosa" },
                    { 10, 1, "Jujuy" },
                    { 11, 1, "La Pampa" },
                    { 12, 1, "La Rioja" },
                    { 13, 1, "Mendoza" },
                    { 14, 1, "Misiones" },
                    { 15, 1, "Neuquén" },
                    { 16, 1, "Río Negro" },
                    { 17, 1, "Salta" },
                    { 18, 1, "San Juan" },
                    { 19, 1, "San Luis" },
                    { 20, 1, "Santa Cruz" },
                    { 21, 1, "Santa Fe" },
                    { 22, 1, "Santiago del Estero" },
                    { 23, 1, "Tierra del Fuego" },
                    { 24, 1, "Tucumán" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "cityId", "city", "stateId" },
                values: new object[,]
                {
                    { 1, "12 De Agosto", 1 },
                    { 2, "12 De Octubre", 1 },
                    { 3, "16 De Julio", 1 },
                    { 4, "17 De Agosto", 1 },
                    { 5, "20 De Junio", 1 },
                    { 6, "25 De Mayo", 1 },
                    { 7, "30 De Agosto", 1 },
                    { 8, "9 De Abril", 1 },
                    { 9, "9 De Julio", 1 },
                    { 10, "Abasto", 1 },
                    { 11, "Abbott", 1 },
                    { 12, "Abel", 1 },
                    { 13, "Abra De Hinojo", 1 },
                    { 14, "Acassuso", 1 },
                    { 15, "Aceilan", 1 },
                    { 16, "Acevedo", 1 },
                    { 17, "Achupallas", 1 },
                    { 18, "Adela", 1 },
                    { 19, "Adela Corti", 1 },
                    { 20, "Adela Saenz", 1 },
                    { 21, "Adolfo Alsina", 1 },
                    { 22, "Adolfo Gonzalez Chavez", 1 },
                    { 23, "Aeropuerto Ezeiza", 1 },
                    { 24, "Agote", 1 },
                    { 25, "Aguara", 1 },
                    { 26, "Aguas Corrientes", 1 },
                    { 27, "Aguas Verdes", 1 },
                    { 28, "Aguirrezabala", 1 },
                    { 29, "Agustin Mosconi", 1 },
                    { 30, "Agustin Roca", 1 },
                    { 31, "Agustina", 1 },
                    { 32, "Alagon", 1 },
                    { 33, "Alamos", 1 },
                    { 34, "Alastuey", 1 },
                    { 35, "Albariño", 1 },
                    { 36, "Alberdi", 1 },
                    { 37, "Alberti", 1 },
                    { 38, "Aldea Romana", 1 },
                    { 39, "Aldea San Andres", 1 },
                    { 40, "Aldecon", 1 },
                    { 41, "Aldo Bonzi", 1 },
                    { 42, "Alegre", 1 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "cityId", "city", "stateId" },
                values: new object[,]
                {
                    { 43, "Alejandro Korn", 1 },
                    { 44, "Alejandro Petion", 1 },
                    { 45, "Alfa", 1 },
                    { 46, "Alfalad", 1 },
                    { 47, "Alferez San Martin", 1 },
                    { 48, "Alfredo Demarchi", 1 },
                    { 49, "Algarrobo", 1 },
                    { 50, "Almacen Castro", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_stateId",
                table: "City",
                column: "stateId");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_countryId",
                table: "State",
                column: "countryId",
                principalTable: "Country",
                principalColumn: "countryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_countryId",
                table: "State");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "stateId",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "countryId",
                table: "State",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_countryId",
                table: "State",
                column: "countryId",
                principalTable: "Country",
                principalColumn: "countryId");
        }
    }
}
