using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddCsvHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CsvHistory",
                columns: table => new
                {
                    Csv_history_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Csv_task_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    File_name = table.Column<string>(type: "TEXT", nullable: false),
                    Direction = table.Column<string>(type: "TEXT", nullable: false),
                    Target = table.Column<string>(type: "TEXT", nullable: false),
                    Result = table.Column<string>(type: "TEXT", nullable: false),
                    Recode_num = table.Column<int>(type: "INTEGER", nullable: false),
                    Error_message = table.Column<string>(type: "TEXT", nullable: false),
                    Device_id = table.Column<string>(type: "TEXT", nullable: false),
                    Executed_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsvHistory", x => x.Csv_history_id);
                    table.ForeignKey(
                        name: "FK_CsvHistory_CsvTaskType_Csv_task_type_id",
                        column: x => x.Csv_task_type_id,
                        principalTable: "CsvTaskType",
                        principalColumn: "Csv_task_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CsvHistory_Csv_task_type_id",
                table: "CsvHistory",
                column: "Csv_task_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CsvHistory");
        }
    }
}
