using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddMemoFieldsToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "Locations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 21:05:10", "2025-12-17 21:05:10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Memo",
                table: "Locations");

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 20:43:30", "2025-12-17 20:43:30" });
        }
    }
}
