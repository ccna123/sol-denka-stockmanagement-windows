using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldMaster2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeFieldSettings_FieldMaster_Field_id",
                table: "ItemTypeFieldSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldMaster",
                table: "FieldMaster");

            migrationBuilder.RenameTable(
                name: "FieldMaster",
                newName: "FieldMasters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldMasters",
                table: "FieldMasters",
                column: "Field_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeFieldSettings_FieldMasters_Field_id",
                table: "ItemTypeFieldSettings",
                column: "Field_id",
                principalTable: "FieldMasters",
                principalColumn: "Field_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeFieldSettings_FieldMasters_Field_id",
                table: "ItemTypeFieldSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldMasters",
                table: "FieldMasters");

            migrationBuilder.RenameTable(
                name: "FieldMasters",
                newName: "FieldMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldMaster",
                table: "FieldMaster",
                column: "Field_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeFieldSettings_FieldMaster_Field_id",
                table: "ItemTypeFieldSettings",
                column: "Field_id",
                principalTable: "FieldMaster",
                principalColumn: "Field_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
