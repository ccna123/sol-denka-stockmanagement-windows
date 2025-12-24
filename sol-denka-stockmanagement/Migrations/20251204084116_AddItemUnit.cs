using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddItemUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemUnits",
                columns: table => new
                {
                    Item_unit_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item_unit_code = table.Column<string>(type: "TEXT", nullable: false),
                    Is_active = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUnits", x => x.Item_unit_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_Item_unit_id",
                table: "ItemTypes",
                column: "Item_unit_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_ItemUnits_Item_unit_id",
                table: "ItemTypes",
                column: "Item_unit_id",
                principalTable: "ItemUnits",
                principalColumn: "Item_unit_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_ItemUnits_Item_unit_id",
                table: "ItemTypes");

            migrationBuilder.DropTable(
                name: "ItemUnits");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypes_Item_unit_id",
                table: "ItemTypes");
        }
    }
}
