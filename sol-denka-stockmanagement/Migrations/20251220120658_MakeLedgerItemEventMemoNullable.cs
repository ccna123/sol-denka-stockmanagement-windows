using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class MakeLedgerItemEventMemoNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Process_type_id",
                table: "LedgerItemEvents",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Memo",
                table: "LedgerItemEvents",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Event_type_id",
                table: "LedgerItemEvents",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "ProcessType",
                keyColumn: "Process_type_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 21:06:58", "2025-12-20 21:06:58" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Process_type_id",
                table: "LedgerItemEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Memo",
                table: "LedgerItemEvents",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Event_type_id",
                table: "LedgerItemEvents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

            migrationBuilder.UpdateData(
                table: "EventTypes",
                keyColumn: "Event_type_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-20 15:28:09", "2025-12-20 15:28:09" });

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
    }
}
