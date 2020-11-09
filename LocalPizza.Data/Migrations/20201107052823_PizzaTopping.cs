using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalPizza.Data.Migrations
{
    public partial class PizzaTopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    ToppingId = table.Column<int>(nullable: false)
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
                        name: "FK_PizzaTopping_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Topping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Topping");
        }
    }
}
