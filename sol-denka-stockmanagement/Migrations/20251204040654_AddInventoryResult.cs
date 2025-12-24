using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_LedgerItems_LedgerItemId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Tags",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "LedgerItemId",
                table: "Tags",
                newName: "Ledger_item_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Tags",
                newName: "Is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Tags",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "Tag_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_LedgerItemId",
                table: "Tags",
                newName: "IX_Tags_Ledger_item_id");

            migrationBuilder.RenameColumn(
                name: "WinderInfo",
                table: "LedgerItems",
                newName: "Winder_info");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "LedgerItems",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "SpecificGravity",
                table: "LedgerItems",
                newName: "Specific_gravity");

            migrationBuilder.RenameColumn(
                name: "MisrollReason",
                table: "LedgerItems",
                newName: "Misroll_reason");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "LedgerItems",
                newName: "Location_id");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "LedgerItems",
                newName: "Item_type_id");

            migrationBuilder.RenameColumn(
                name: "IsInStock",
                table: "LedgerItems",
                newName: "Is_in_stock");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "LedgerItems",
                newName: "Is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "LedgerItems",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "LedgerItemId",
                table: "LedgerItems",
                newName: "Ledger_item_id");

            migrationBuilder.CreateTable(
                name: "InventoryResults",
                columns: table => new
                {
                    Inventory_result_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inventory_sesstion_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Inventory_result_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ledger_item_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Tag_id = table.Column<int>(type: "INTEGER", nullable: false),
                    System_location_id_at_scan = table.Column<int>(type: "INTEGER", nullable: false),
                    System_is_in_stock_at_scan = table.Column<int>(type: "INTEGER", nullable: false),
                    Scanned_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryResults", x => x.Inventory_result_id);
                    table.ForeignKey(
                        name: "FK_InventoryResults_Tags_Tag_id",
                        column: x => x.Tag_id,
                        principalTable: "Tags",
                        principalColumn: "Tag_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryResults_Tag_id",
                table: "InventoryResults",
                column: "Tag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_LedgerItems_Ledger_item_id",
                table: "Tags",
                column: "Ledger_item_id",
                principalTable: "LedgerItems",
                principalColumn: "Ledger_item_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_LedgerItems_Ledger_item_id",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "InventoryResults");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Tags",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Ledger_item_id",
                table: "Tags",
                newName: "LedgerItemId");

            migrationBuilder.RenameColumn(
                name: "Is_active",
                table: "Tags",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Tags",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Tag_id",
                table: "Tags",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_Ledger_item_id",
                table: "Tags",
                newName: "IX_Tags_LedgerItemId");

            migrationBuilder.RenameColumn(
                name: "Winder_info",
                table: "LedgerItems",
                newName: "WinderInfo");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "LedgerItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Specific_gravity",
                table: "LedgerItems",
                newName: "SpecificGravity");

            migrationBuilder.RenameColumn(
                name: "Misroll_reason",
                table: "LedgerItems",
                newName: "MisrollReason");

            migrationBuilder.RenameColumn(
                name: "Location_id",
                table: "LedgerItems",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Item_type_id",
                table: "LedgerItems",
                newName: "ItemTypeId");

            migrationBuilder.RenameColumn(
                name: "Is_in_stock",
                table: "LedgerItems",
                newName: "IsInStock");

            migrationBuilder.RenameColumn(
                name: "Is_active",
                table: "LedgerItems",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "LedgerItems",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Ledger_item_id",
                table: "LedgerItems",
                newName: "LedgerItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_LedgerItems_LedgerItemId",
                table: "Tags",
                column: "LedgerItemId",
                principalTable: "LedgerItems",
                principalColumn: "LedgerItemId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
