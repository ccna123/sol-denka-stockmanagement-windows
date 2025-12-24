using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedItemCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemCatetories",
                columns: new[] { "Item_category_id", "Created_at", "Item_category_name", "Keyword", "Updated_at" },
                values: new object[,]
                {
                    { 1, "2025-12-13 02:07:57", "副資材", null, "2025-12-13 02:07:57" },
                    { 2, "2025-12-13 02:07:57", "副原料", null, "2025-12-13 02:07:57" },
                    { 3, "2025-12-13 02:07:57", "各外品", null, "2025-12-13 02:07:57" },
                    { 4, "2025-12-13 02:07:57", "半製品", null, "2025-12-13 02:07:57" },
                    { 5, "2025-12-13 02:07:57", "中間品", null, "2025-12-13 02:07:57" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5);
        }
    }
}
