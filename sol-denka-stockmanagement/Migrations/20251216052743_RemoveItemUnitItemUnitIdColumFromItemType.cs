using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveItemUnitItemUnitIdColumFromItemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemUnitItem_unit_id",
                table: "ItemTypes");
            migrationBuilder.DropColumn(
                name: "ItemUnitItem_unit_id1",
                table: "ItemTypes");
            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:27:43", "2025-12-16 14:27:43" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-16 14:20:46", "2025-12-16 14:20:46" });
        }
    }
}
