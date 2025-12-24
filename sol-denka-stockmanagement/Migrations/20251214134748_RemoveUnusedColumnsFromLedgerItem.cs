using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedColumnsFromLedgerItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_at",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Misroll_reason",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Specific_gravity",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Winder_info",
                table: "LedgerItems");

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:47:47", "2025-12-14 22:47:47" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Created_at",
                table: "LedgerItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "LedgerItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Misroll_reason",
                table: "LedgerItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Specific_gravity",
                table: "LedgerItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Winder_info",
                table: "LedgerItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 21:48:40", "2025-12-14 21:48:40" });
        }
    }
}
