using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalPizza.Data.Migrations
{
    public partial class DeliveryTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestDeliveryTime",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestDeliveryTime",
                table: "Orders");
        }
    }
}
