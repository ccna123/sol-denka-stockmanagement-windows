using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class FixItemUnitSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Item_unit_id", "Created_at", "Item_unit_code", "Keyword", "Unit_category", "Updated_at", "item_unit_name" },
                values: new object[,]
                {
                    { 1, "2025-12-14 21:48:40", "KG", null, 0, "2025-12-14 21:48:40", "kg" },
                    { 2, "2025-12-14 21:48:40", "TON", null, 0, "2025-12-14 21:48:40", "t" },
                    { 3, "2025-12-14 21:48:40", "HON", null, 0, "2025-12-14 21:48:40", "本" },
                    { 4, "2025-12-14 21:48:40", "MAI", null, 0, "2025-12-14 21:48:40", "枚" },
                    { 5, "2025-12-14 21:48:40", "KAN", null, 0, "2025-12-14 21:48:40", "缶" },
                    { 6, "2025-12-14 21:48:40", "TAI", null, 0, "2025-12-14 21:48:40", "袋" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-13 02:07:57", "2025-12-13 02:07:57" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-13 02:07:57", "2025-12-13 02:07:57" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-13 02:07:57", "2025-12-13 02:07:57" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-13 02:07:57", "2025-12-13 02:07:57" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-13 02:07:57", "2025-12-13 02:07:57" });
        }
    }
}
