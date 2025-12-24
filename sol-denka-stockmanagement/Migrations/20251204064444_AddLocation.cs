using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryResults_InventorySessions_Inventory_session_id",
                table: "InventoryResults");

            migrationBuilder.DropIndex(
                name: "IX_InventoryResultTypes_Inventory_result_code",
                table: "InventoryResultTypes");

            migrationBuilder.RenameColumn(
                name: "ledger_item_id",
                table: "InventoryResults",
                newName: "Ledger_item_id");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location_code = table.Column<string>(type: "TEXT", nullable: false),
                    Location_name = table.Column<string>(type: "TEXT", nullable: false),
                    Is_active = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventorySessions_Location_id",
                table: "InventorySessions",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryResults_Ledger_item_id",
                table: "InventoryResults",
                column: "Ledger_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryResults_System_location_id_at_scan",
                table: "InventoryResults",
                column: "System_location_id_at_scan");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryResults_InventorySessions_Inventory_session_id",
                table: "InventoryResults",
                column: "Inventory_session_id",
                principalTable: "InventorySessions",
                principalColumn: "Inventory_session_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryResults_LedgerItems_Ledger_item_id",
                table: "InventoryResults",
                column: "Ledger_item_id",
                principalTable: "LedgerItems",
                principalColumn: "Ledger_item_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryResults_Locations_System_location_id_at_scan",
                table: "InventoryResults",
                column: "System_location_id_at_scan",
                principalTable: "Locations",
                principalColumn: "Location_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InventorySessions_Locations_Location_id",
                table: "InventorySessions",
                column: "Location_id",
                principalTable: "Locations",
                principalColumn: "Location_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryResults_InventorySessions_Inventory_session_id",
                table: "InventoryResults");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryResults_LedgerItems_Ledger_item_id",
                table: "InventoryResults");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryResults_Locations_System_location_id_at_scan",
                table: "InventoryResults");

            migrationBuilder.DropForeignKey(
                name: "FK_InventorySessions_Locations_Location_id",
                table: "InventorySessions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_InventorySessions_Location_id",
                table: "InventorySessions");

            migrationBuilder.DropIndex(
                name: "IX_InventoryResults_Ledger_item_id",
                table: "InventoryResults");

            migrationBuilder.DropIndex(
                name: "IX_InventoryResults_System_location_id_at_scan",
                table: "InventoryResults");

            migrationBuilder.RenameColumn(
                name: "Ledger_item_id",
                table: "InventoryResults",
                newName: "ledger_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryResultTypes_Inventory_result_code",
                table: "InventoryResultTypes",
                column: "Inventory_result_code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryResults_InventorySessions_Inventory_session_id",
                table: "InventoryResults",
                column: "Inventory_session_id",
                principalTable: "InventorySessions",
                principalColumn: "Inventory_session_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
