using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddLedgerItemColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Updated_at",
                table: "LedgerItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Lot_no",
                table: "LedgerItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "LedgerItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occurred_at",
                table: "LedgerItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occurrence_reason",
                table: "LedgerItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Processed_at",
                table: "LedgerItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Registered_at",
                table: "LedgerItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Winder_id",
                table: "LedgerItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-14 22:49:51", "2025-12-14 22:49:51" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lot_no",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Memo",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Occurred_at",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Occurrence_reason",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Processed_at",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Registered_at",
                table: "LedgerItems");

            migrationBuilder.DropColumn(
                name: "Winder_id",
                table: "LedgerItems");

            migrationBuilder.AlterColumn<string>(
                name: "Updated_at",
                table: "LedgerItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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
    }
}
