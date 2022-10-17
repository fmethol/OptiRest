using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiRest.Data.Migrations
{
    public partial class TableService2Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableService2Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableServiceId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableService2Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableService2Items_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableService2Items_TableServices_TableServiceId",
                        column: x => x.TableServiceId,
                        principalTable: "TableServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableService2Items_ItemId",
                table: "TableService2Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TableService2Items_TableServiceId",
                table: "TableService2Items",
                column: "TableServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableService2Items");
        }
    }
}
