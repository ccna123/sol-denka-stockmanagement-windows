using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddProcessType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessType",
                columns: table => new
                {
                    Process_type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Process_code = table.Column<string>(type: "TEXT", nullable: false),
                    Process_name = table.Column<string>(type: "TEXT", nullable: false),
                    Is_active = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessType", x => x.Process_type_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LedgerItemEvents_Process_type_id",
                table: "LedgerItemEvents",
                column: "Process_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerItemEvents_ProcessType_Process_type_id",
                table: "LedgerItemEvents",
                column: "Process_type_id",
                principalTable: "ProcessType",
                principalColumn: "Process_type_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerItemEvents_ProcessType_Process_type_id",
                table: "LedgerItemEvents");

            migrationBuilder.DropTable(
                name: "ProcessType");

            migrationBuilder.DropIndex(
                name: "IX_LedgerItemEvents_Process_type_id",
                table: "LedgerItemEvents");
        }
    }
}
