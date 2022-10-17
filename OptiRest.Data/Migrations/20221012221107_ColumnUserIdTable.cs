using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiRest.Data.Migrations
{
    public partial class ColumnUserIdTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tables");
        }
    }
}
