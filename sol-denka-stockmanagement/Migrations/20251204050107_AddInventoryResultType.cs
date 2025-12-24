using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryResultType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryResultTypes",
                columns: table => new
                {
                    Inventory_result_type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inventory_result_code = table.Column<string>(type: "TEXT", nullable: false),
                    Inventory_result_name = table.Column<string>(type: "TEXT", nullable: false),
                    Is_active = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryResultTypes", x => x.Inventory_result_type_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryResults_Inventory_result_type_id",
                table: "InventoryResults",
                column: "Inventory_result_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryResultTypes_Inventory_result_code",
                table: "InventoryResultTypes",
                column: "Inventory_result_code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryResults_InventoryResultTypes_Inventory_result_type_id",
                table: "InventoryResults",
                column: "Inventory_result_type_id",
                principalTable: "InventoryResultTypes",
                principalColumn: "Inventory_result_type_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryResults_InventoryResultTypes_Inventory_result_type_id",
                table: "InventoryResults");

            migrationBuilder.DropTable(
                name: "InventoryResultTypes");

            migrationBuilder.DropIndex(
                name: "IX_InventoryResults_Inventory_result_type_id",
                table: "InventoryResults");
        }
    }
}
