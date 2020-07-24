using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalPizza.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuTypes",
                columns: table => new
                {
                    MenuTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTypes", x => x.MenuTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    MenuTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_MenuTypes_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalTable: "MenuTypes",
                        principalColumn: "MenuTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MenuTypes",
                columns: new[] { "MenuTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Pizza" },
                    { 2, "Side" },
                    { 3, "Dessert" },
                    { 4, "Drink" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Description", "MenuTypeId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Huge pie cut into 8 extra-large slices. Authentic, soft & foldable New York-style dough, topped with Marinara pizza sauce & lots of stretchy mozzarella", 1, "The Big Cheese", 15.1 },
                    { 2, "Huge pie cut into 8 extra-large slices. Authentic, soft & foldable New York-style dough, topped with Marinara pizza sauce & lots of crispy American pepperoni with hints of fennel & chilli", 1, "The Big Pepperoni", 17.5 },
                    { 3, "Succulent chicken, crispy rasher bacon, spinach and red onion, topped with a creamy ranch sauce and served on a pizza sauce base with zesty garlic sauce", 1, "Garlic Chicken & Bacon Ranch", 12.5 },
                    { 4, "The perfect combination of succulent chicken pieces, crispy rasher bacon & slices of red onion on a BBQ sauce base", 1, "Bbq Chicken & Rasher Bacon", 12.6 },
                    { 5, "Juicy prawns, paired with fresh baby spinach & diced tomato on a crème fraiche & zesty garlic sauce base, topped with oregano", 1, "Garlic Prawn", 12.699999999999999 },
                    { 6, "Dipping Sauce", 2, "Ranch Dipping Sauce", 0.5 },
                    { 7, "Oven baked chips dusted with chicken salt", 2, "Oven Baked Chips", 5.5 },
                    { 8, "Freshly oven baked herb & garlic bread, topped with stretchy mozzarella", 2, "Cheesy Garlic Bread", 8.9000000000000004 },
                    { 9, "A classic vanilla sundae drizzled with salted caramel sauce", 3, "Salted Caramel Sundae", 2.9500000000000002 },
                    { 10, "A classic vanilla sundae drizzled with decadent chocolate sauce", 3, "2 Choc Sundaes", 5.0999999999999996 },
                    { 11, "1.25L", 4, "Pepsi", 4.9000000000000004 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_MenuTypeId",
                table: "Items",
                column: "MenuTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "MenuTypes");
        }
    }
}