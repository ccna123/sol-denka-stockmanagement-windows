using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedEventType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Event_type_id", "Created_at", "Event_code", "Event_name", "Updated_at" },
                values: new object[,]
                {
                    { 1, "2025-12-20 15:28:09", "STOCK_IN", "入庫", "2025-12-20 15:28:09" },
                    { 2, "2025-12-20 15:28:09", "STOCK_OUT", "出庫", "2025-12-20 15:28:09" },
                    { 3, "2025-12-20 15:28:09", "MOVE", "保管場所移動", "2025-12-20 15:28:09" },
                    { 4, "2025-12-20 15:28:09", "INVENTORY_STOCK_IN", "棚卸入庫(自動)", "2025-12-20 15:28:09" },
                    { 5, "2025-12-20 15:28:09", "INVENTORY_STOCK_OUT", "棚卸出庫(自動)", "2025-12-20 15:28:09" },
                    { 6, "2025-12-20 15:28:09", "INVENTORY_MOVE", "棚卸保管場所移動(自動)", "2025-12-20 15:28:09" },
                    { 7, "2025-12-20 15:28:09", "EDIT", "編集", "2025-12-20 15:28:09" }
                });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 14:55:27", "2025-12-20 14:55:27" });
        }
    }
}
