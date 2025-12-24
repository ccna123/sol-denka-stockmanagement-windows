using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitCategoryAndItemUnitNameToItemUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Unit_category",
                table: "ItemUnits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "item_unit_name",
                table: "ItemUnits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit_category",
                table: "ItemUnits");

            migrationBuilder.DropColumn(
                name: "item_unit_name",
                table: "ItemUnits");
        }
    }
}
