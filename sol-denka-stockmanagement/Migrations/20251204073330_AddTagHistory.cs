using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddTagHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagHistories",
                columns: table => new
                {
                    Tag_history_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tag_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Ledger_item_id = table.Column<int>(type: "INTEGER", nullable: true),
                    Tag_action_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Occured_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagHistories", x => x.Tag_history_id);
                    table.ForeignKey(
                        name: "FK_TagHistories_LedgerItems_Ledger_item_id",
                        column: x => x.Ledger_item_id,
                        principalTable: "LedgerItems",
                        principalColumn: "Ledger_item_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TagHistories_Tags_Tag_id",
                        column: x => x.Tag_id,
                        principalTable: "Tags",
                        principalColumn: "Tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LedgerItems_Location_id",
                table: "LedgerItems",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_TagHistories_Ledger_item_id",
                table: "TagHistories",
                column: "Ledger_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_TagHistories_Tag_id",
                table: "TagHistories",
                column: "Tag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerItems_Locations_Location_id",
                table: "LedgerItems",
                column: "Location_id",
                principalTable: "Locations",
                principalColumn: "Location_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerItems_Locations_Location_id",
                table: "LedgerItems");

            migrationBuilder.DropTable(
                name: "TagHistories");

            migrationBuilder.DropIndex(
                name: "IX_LedgerItems_Location_id",
                table: "LedgerItems");
        }
    }
}
