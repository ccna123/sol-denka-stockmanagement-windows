using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class FixNullabilityItemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_ItemUnits_ItemUnitItem_unit_id",
                table: "ItemTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_ItemUnits_ItemUnitItem_unit_id1",
                table: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypes_ItemUnitItem_unit_id",
                table: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypes_ItemUnitItem_unit_id1",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "ItemUnitItem_unit_id",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "ItemUnitItem_unit_id1",
                table: "ItemTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Specific_gravity",
                table: "ItemTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Packing_type",
                table: "ItemTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Item_category_id",
                table: "ItemTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "ItemTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "TagEventTypes",
                keyColumn: "Tag_event_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-17 17:41:53", "2025-12-17 17:41:53" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Specific_gravity",
                table: "ItemTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Packing_type",
                table: "ItemTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Item_category_id",
                table: "ItemTypes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "ItemTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemUnitItem_unit_id",
                table: "ItemTypes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemUnitItem_unit_id1",
                table: "ItemTypes",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_ItemUnitItem_unit_id",
                table: "ItemTypes",
                column: "ItemUnitItem_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_ItemUnitItem_unit_id1",
                table: "ItemTypes",
                column: "ItemUnitItem_unit_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_ItemUnits_ItemUnitItem_unit_id",
                table: "ItemTypes",
                column: "ItemUnitItem_unit_id",
                principalTable: "ItemUnits",
                principalColumn: "Item_unit_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_ItemUnits_ItemUnitItem_unit_id1",
                table: "ItemTypes",
                column: "ItemUnitItem_unit_id1",
                principalTable: "ItemUnits",
                principalColumn: "Item_unit_id");
        }
    }
}
