using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiRest.Migrations
{
    public partial class ActualizarPlato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Platos",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Platos",
                newName: "MyProperty");
        }
    }
}
