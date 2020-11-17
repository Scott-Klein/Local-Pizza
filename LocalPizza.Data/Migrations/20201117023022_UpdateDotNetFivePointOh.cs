using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalPizza.Data.Migrations
{
    public partial class UpdateDotNetFivePointOh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PizzaTopping",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.ItemId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId");
        }
    }
}
