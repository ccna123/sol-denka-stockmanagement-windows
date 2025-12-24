using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedWinderMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:10:01", "2025-12-14 23:10:01" });

            migrationBuilder.InsertData(
                table: "Winders",
                columns: new[] { "Winder_id", "Created_at", "Updated_at", "Winder_name" },
                values: new object[,]
                {
                    { 1, "2025-12-14 23:10:01", "2025-12-14 23:10:01", "2号機" },
                    { 2, "2025-12-14 23:10:01", "2025-12-14 23:10:01", "Bスリ B" },
                    { 3, "2025-12-14 23:10:01", "2025-12-14 23:10:01", "Bスリ F" },
                    { 4, "2025-12-14 23:10:01", "2025-12-14 23:10:01", "3号機 No.1" },
                    { 5, "2025-12-14 23:10:01", "2025-12-14 23:10:01", "3号機 No.2" },
                    { 6, "2025-12-14 23:10:01", "2025-12-14 23:10:01", "4号機 No.1" },
                    { 7, "2025-12-14 23:10:01", "2025-12-14 23:10:01", "4号機 No.2" },
                    { 8, "2025-12-14 23:10:01", "2025-12-14 23:10:01", "その他" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 23:03:45", "2025-12-14 23:03:45" });
        }
    }
}
