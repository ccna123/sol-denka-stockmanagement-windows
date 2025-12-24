using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddLedgerItemEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LedgerItemEventEvent_id",
                table: "InventoryResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LedgerItemEvents",
                columns: table => new
                {
                    Event_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ledger_item_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Event_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Process_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Location_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Occurred_at = table.Column<string>(type: "TEXT", nullable: false),
                    Registered_at = table.Column<string>(type: "TEXT", nullable: false),
                    Memo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerItemEvents", x => x.Event_id);
                    table.ForeignKey(
                        name: "FK_LedgerItemEvents_LedgerItems_Ledger_item_id",
                        column: x => x.Ledger_item_id,
                        principalTable: "LedgerItems",
                        principalColumn: "Ledger_item_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryResults_LedgerItemEventEvent_id",
                table: "InventoryResults",
                column: "LedgerItemEventEvent_id");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerItemEvents_Ledger_item_id",
                table: "LedgerItemEvents",
                column: "Ledger_item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryResults_LedgerItemEvents_LedgerItemEventEvent_id",
                table: "InventoryResults",
                column: "LedgerItemEventEvent_id",
                principalTable: "LedgerItemEvents",
                principalColumn: "Event_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryResults_LedgerItemEvents_LedgerItemEventEvent_id",
                table: "InventoryResults");

            migrationBuilder.DropTable(
                name: "LedgerItemEvents");

            migrationBuilder.DropIndex(
                name: "IX_InventoryResults_LedgerItemEventEvent_id",
                table: "InventoryResults");

            migrationBuilder.DropColumn(
                name: "LedgerItemEventEvent_id",
                table: "InventoryResults");
        }
    }
}
