using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaStoreManagmentAPI.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "Pizzas",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Availability", "Name", "price", "size" },
                values: new object[] { 101, "In Stock", "Pepperoni Pizza", 120, "Large" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Availability", "Name", "price", "size" },
                values: new object[] { 102, "Out of Stock", "Veggie Pizza", 80, "Medium" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Availability", "Name", "price", "size" },
                values: new object[] { 103, "In Stock", "BBQ Chicken Pizza", 90, "Small" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.AlterColumn<float>(
                name: "price",
                table: "Pizzas",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Availability", "Name", "price", "size" },
                values: new object[] { 201, "In Stock", "Pepperoni Pizza", 120f, "Large" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Availability", "Name", "price", "size" },
                values: new object[] { 202, "Out of Stock", "Veggie Pizza", 80f, "Medium" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Availability", "Name", "price", "size" },
                values: new object[] { 203, "In Stock", "BBQ Chicken Pizza", 90f, "Small" });
        }
    }
}
