using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddInventorySession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inventory_sesstion_id",
                table: "InventoryResults",
                newName: "Inventory_session_id");

            migrationBuilder.CreateTable(
                name: "InventorySessions",
                columns: table => new
                {
                    Inventory_session_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Device_id = table.Column<string>(type: "TEXT", nullable: false),
                    Executed_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventorySessions", x => x.Inventory_session_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryResults_Inventory_session_id",
                table: "InventoryResults",
                column: "Inventory_session_id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryResults_InventorySessions_Inventory_session_id",
                table: "InventoryResults",
                column: "Inventory_session_id",
                principalTable: "InventorySessions",
                principalColumn: "Inventory_session_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryResults_InventorySessions_Inventory_session_id",
                table: "InventoryResults");

            migrationBuilder.DropTable(
                name: "InventorySessions");

            migrationBuilder.DropIndex(
                name: "IX_InventoryResults_Inventory_session_id",
                table: "InventoryResults");

            migrationBuilder.RenameColumn(
                name: "Inventory_session_id",
                table: "InventoryResults",
                newName: "Inventory_sesstion_id");
        }
    }
}
