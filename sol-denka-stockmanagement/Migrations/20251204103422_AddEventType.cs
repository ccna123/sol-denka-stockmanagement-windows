using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddEventType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Event_type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Event_code = table.Column<string>(type: "TEXT", nullable: false),
                    Event_name = table.Column<string>(type: "TEXT", nullable: false),
                    Is_active = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Event_type_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LedgerItemEvents_Event_type_id",
                table: "LedgerItemEvents",
                column: "Event_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerItemEvents_EventType_Event_type_id",
                table: "LedgerItemEvents",
                column: "Event_type_id",
                principalTable: "EventType",
                principalColumn: "Event_type_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerItemEvents_EventType_Event_type_id",
                table: "LedgerItemEvents");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropIndex(
                name: "IX_LedgerItemEvents_Event_type_id",
                table: "LedgerItemEvents");
        }
    }
}
