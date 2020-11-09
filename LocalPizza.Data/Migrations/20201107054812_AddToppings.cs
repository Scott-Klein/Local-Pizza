using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalPizza.Data.Migrations
{
    public partial class AddToppings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTopping_Topping_ToppingId",
                table: "PizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTopping_Toppings_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTopping_Toppings_ToppingId",
                table: "PizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTopping_Topping_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId",
                principalTable: "Topping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
