using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddItemTypeFieldSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemTypeFieldSettings",
                columns: table => new
                {
                    Item_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Field_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Is_required = table.Column<int>(type: "INTEGER", nullable: false),
                    Is_visible = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeFieldSettings", x => new { x.Item_type_id, x.Field_id });
                    table.ForeignKey(
                        name: "FK_ItemTypeFieldSettings_ItemTypes_Item_type_id",
                        column: x => x.Item_type_id,
                        principalTable: "ItemTypes",
                        principalColumn: "Item_type_id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTypeFieldSettings");
        }
    }
}
