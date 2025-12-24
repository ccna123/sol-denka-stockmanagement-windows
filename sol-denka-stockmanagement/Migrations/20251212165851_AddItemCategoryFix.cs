using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddItemCategoryFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Item_category_id",
                table: "ItemTypes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemCatetories",
                columns: table => new
                {
                    Item_category_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item_category_name = table.Column<string>(type: "TEXT", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false),
                    Keyword = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCatetories", x => x.Item_category_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_Item_category_id",
                table: "ItemTypes",
                column: "Item_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_ItemCatetories_Item_category_id",
                table: "ItemTypes",
                column: "Item_category_id",
                principalTable: "ItemCatetories",
                principalColumn: "Item_category_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_ItemCatetories_Item_category_id",
                table: "ItemTypes");

            migrationBuilder.DropTable(
                name: "ItemCatetories");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypes_Item_category_id",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "Item_category_id",
                table: "ItemTypes");
        }
    }
}
