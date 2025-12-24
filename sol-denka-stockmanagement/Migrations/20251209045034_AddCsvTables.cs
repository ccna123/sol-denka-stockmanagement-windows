using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddCsvTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CsvHistory_CsvTaskType_Csv_task_type_id",
                table: "CsvHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsvTaskType",
                table: "CsvTaskType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsvHistory",
                table: "CsvHistory");

            migrationBuilder.RenameTable(
                name: "CsvTaskType",
                newName: "CsvTaskTypes");

            migrationBuilder.RenameTable(
                name: "CsvHistory",
                newName: "CsvHistories");

            migrationBuilder.RenameIndex(
                name: "IX_CsvHistory_Csv_task_type_id",
                table: "CsvHistories",
                newName: "IX_CsvHistories_Csv_task_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsvTaskTypes",
                table: "CsvTaskTypes",
                column: "Csv_task_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsvHistories",
                table: "CsvHistories",
                column: "Csv_history_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CsvHistories_CsvTaskTypes_Csv_task_type_id",
                table: "CsvHistories",
                column: "Csv_task_type_id",
                principalTable: "CsvTaskTypes",
                principalColumn: "Csv_task_type_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CsvHistories_CsvTaskTypes_Csv_task_type_id",
                table: "CsvHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsvTaskTypes",
                table: "CsvTaskTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CsvHistories",
                table: "CsvHistories");

            migrationBuilder.RenameTable(
                name: "CsvTaskTypes",
                newName: "CsvTaskType");

            migrationBuilder.RenameTable(
                name: "CsvHistories",
                newName: "CsvHistory");

            migrationBuilder.RenameIndex(
                name: "IX_CsvHistories_Csv_task_type_id",
                table: "CsvHistory",
                newName: "IX_CsvHistory_Csv_task_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsvTaskType",
                table: "CsvTaskType",
                column: "Csv_task_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CsvHistory",
                table: "CsvHistory",
                column: "Csv_history_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CsvHistory_CsvTaskType_Csv_task_type_id",
                table: "CsvHistory",
                column: "Csv_task_type_id",
                principalTable: "CsvTaskType",
                principalColumn: "Csv_task_type_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
