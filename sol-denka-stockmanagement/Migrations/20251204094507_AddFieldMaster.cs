using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldMaster",
                columns: table => new
                {
                    Field_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Field_name = table.Column<string>(type: "TEXT", nullable: false),
                    Data_type = table.Column<string>(type: "TEXT", nullable: false),
                    Max_length = table.Column<int>(type: "INTEGER", nullable: false),
                    Min_value = table.Column<int>(type: "INTEGER", nullable: false),
                    Max_value = table.Column<int>(type: "INTEGER", nullable: false),
                    Regex_pattern = table.Column<string>(type: "TEXT", nullable: false),
                    Control_type = table.Column<string>(type: "TEXT", nullable: false),
                    Is_active = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldMaster", x => x.Field_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeFieldSettings_Field_id",
                table: "ItemTypeFieldSettings",
                column: "Field_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeFieldSettings_FieldMaster_Field_id",
                table: "ItemTypeFieldSettings",
                column: "Field_id",
                principalTable: "FieldMaster",
                principalColumn: "Field_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeFieldSettings_FieldMaster_Field_id",
                table: "ItemTypeFieldSettings");

            migrationBuilder.DropTable(
                name: "FieldMaster");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypeFieldSettings_Field_id",
                table: "ItemTypeFieldSettings");
        }
    }
}
