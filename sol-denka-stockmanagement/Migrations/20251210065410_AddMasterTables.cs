using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerItemEvents_EventType_Event_type_id",
                table: "LedgerItemEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventType",
                table: "EventType");

            migrationBuilder.RenameTable(
                name: "EventType",
                newName: "EventTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTypes",
                table: "EventTypes",
                column: "Event_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerItemEvents_EventTypes_Event_type_id",
                table: "LedgerItemEvents",
                column: "Event_type_id",
                principalTable: "EventTypes",
                principalColumn: "Event_type_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerItemEvents_EventTypes_Event_type_id",
                table: "LedgerItemEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTypes",
                table: "EventTypes");

            migrationBuilder.RenameTable(
                name: "EventTypes",
                newName: "EventType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventType",
                table: "EventType",
                column: "Event_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerItemEvents_EventType_Event_type_id",
                table: "LedgerItemEvents",
                column: "Event_type_id",
                principalTable: "EventType",
                principalColumn: "Event_type_id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
