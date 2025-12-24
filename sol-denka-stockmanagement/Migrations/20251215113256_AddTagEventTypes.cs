using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddTagEventTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagHistories_TagActionTypes_Tag_action_id",
                table: "TagHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagStatusTypes_Tag_status_id",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_TagHistories_Tag_action_id",
                table: "TagHistories");

            migrationBuilder.DropColumn(
                name: "Tag_action_id",
                table: "TagHistories");

            migrationBuilder.AddColumn<int>(
                name: "Tag_event_id",
                table: "TagHistories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TagEventTypes",
                columns: table => new
                {
                    Tag_event_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Event_code = table.Column<string>(type: "TEXT", nullable: false),
                    Event_name = table.Column<string>(type: "TEXT", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEventTypes", x => x.Tag_event_id);
                });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.InsertData(
                table: "TagEventTypes",
                columns: new[] { "Tag_event_id", "Created_at", "Event_code", "Event_name", "Updated_at" },
                values: new object[,]
                {
                    { 1, "2025-12-15 20:32:56", "REGISTERED", "登録", "2025-12-15 20:32:56" },
                    { 2, "2025-12-15 20:32:56", "ATTACH", "紐づけ", "2025-12-15 20:32:56" },
                    { 3, "2025-12-15 20:32:56", "DETACH", "紐づけ解除", "2025-12-15 20:32:56" },
                    { 4, "2025-12-15 20:32:56", "DISABLED", "無効", "2025-12-15 20:32:56" }
                });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 20:32:56", "2025-12-15 20:32:56" });

            migrationBuilder.CreateIndex(
                name: "IX_TagHistories_Tag_event_id",
                table: "TagHistories",
                column: "Tag_event_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagHistories_TagEventTypes_Tag_event_id",
                table: "TagHistories",
                column: "Tag_event_id",
                principalTable: "TagEventTypes",
                principalColumn: "Tag_event_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagStatusTypes_Tag_status_id",
                table: "Tags",
                column: "Tag_status_id",
                principalTable: "TagStatusTypes",
                principalColumn: "Tag_status_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagHistories_TagEventTypes_Tag_event_id",
                table: "TagHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagStatusTypes_Tag_status_id",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "TagEventTypes");

            migrationBuilder.DropIndex(
                name: "IX_TagHistories_Tag_event_id",
                table: "TagHistories");

            migrationBuilder.DropColumn(
                name: "Tag_event_id",
                table: "TagHistories");

            migrationBuilder.AddColumn<int>(
                name: "Tag_action_id",
                table: "TagHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemCatetories",
                keyColumn: "Item_category_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "ItemUnits",
                keyColumn: "Item_unit_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "TagStatusTypes",
                keyColumn: "Tag_status_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 6,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 7,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.UpdateData(
                table: "Winders",
                keyColumn: "Winder_id",
                keyValue: 8,
                columns: new[] { "Created_at", "Updated_at" },
                values: new object[] { "2025-12-15 00:54:26", "2025-12-15 00:54:26" });

            migrationBuilder.CreateIndex(
                name: "IX_TagHistories_Tag_action_id",
                table: "TagHistories",
                column: "Tag_action_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagHistories_TagActionTypes_Tag_action_id",
                table: "TagHistories",
                column: "Tag_action_id",
                principalTable: "TagActionTypes",
                principalColumn: "Tag_action_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagStatusTypes_Tag_status_id",
                table: "Tags",
                column: "Tag_status_id",
                principalTable: "TagStatusTypes",
                principalColumn: "Tag_status_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
