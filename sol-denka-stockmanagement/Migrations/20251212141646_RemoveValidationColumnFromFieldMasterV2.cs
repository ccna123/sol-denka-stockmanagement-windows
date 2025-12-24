using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveValidationColumnFromFieldMasterV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Max_length",
                table: "FieldMaster");

            migrationBuilder.DropColumn(
                name: "Max_value",
                table: "FieldMaster");

            migrationBuilder.DropColumn(
                name: "Min_value",
                table: "FieldMaster");

            migrationBuilder.DropColumn(
                name: "Regex_pattern",
                table: "FieldMaster");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Max_length",
                table: "FieldMaster",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Max_value",
                table: "FieldMaster",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Min_value",
                table: "FieldMaster",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Regex_pattern",
                table: "FieldMaster",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
