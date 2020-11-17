using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalPizza.Data.Migrations
{
    public partial class ManyToPizzaTopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Items_ItemId",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_ItemId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Toppings");

            migrationBuilder.CreateTable(
                name: "ItemTopping",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    ToppingsListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTopping", x => new { x.ItemsId, x.ToppingsListId });
                    table.ForeignKey(
                        name: "FK_ItemTopping_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTopping_Toppings_ToppingsListId",
                        column: x => x.ToppingsListId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTopping_ToppingsListId",
                table: "ItemTopping",
                column: "ToppingsListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTopping");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Toppings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_ItemId",
                table: "Toppings",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Items_ItemId",
                table: "Toppings",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
