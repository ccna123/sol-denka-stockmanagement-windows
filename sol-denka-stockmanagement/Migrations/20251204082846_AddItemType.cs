using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddItemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Locations_Location_id",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_TagHistories_TagActionType_TagActionTypeTag_action_id",
                table: "TagHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TagHistories_TagActionType_Tag_action_id",
                table: "TagHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagActionType",
                table: "TagActionType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.RenameTable(
                name: "TagActionType",
                newName: "TagActionTypes");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "Stocks");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_Location_id",
                table: "Stocks",
                newName: "IX_Stocks_Location_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagActionTypes",
                table: "TagActionTypes",
                column: "Tag_action_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Stock_id");

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Item_type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item_type_code = table.Column<string>(type: "TEXT", nullable: true),
                    Item_type_name = table.Column<string>(type: "TEXT", nullable: false),
                    Item_unit_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Is_active = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Item_type_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LedgerItems_Item_type_id",
                table: "LedgerItems",
                column: "Item_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Item_type_id",
                table: "Stocks",
                column: "Item_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_Item_type_code",
                table: "ItemTypes",
                column: "Item_type_code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerItems_ItemTypes_Item_type_id",
                table: "LedgerItems",
                column: "Item_type_id",
                principalTable: "ItemTypes",
                principalColumn: "Item_type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ItemTypes_Item_type_id",
                table: "Stocks",
                column: "Item_type_id",
                principalTable: "ItemTypes",
                principalColumn: "Item_type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Locations_Location_id",
                table: "Stocks",
                column: "Location_id",
                principalTable: "Locations",
                principalColumn: "Location_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TagHistories_TagActionTypes_TagActionTypeTag_action_id",
                table: "TagHistories",
                column: "TagActionTypeTag_action_id",
                principalTable: "TagActionTypes",
                principalColumn: "Tag_action_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagHistories_TagActionTypes_Tag_action_id",
                table: "TagHistories",
                column: "Tag_action_id",
                principalTable: "TagActionTypes",
                principalColumn: "Tag_action_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedgerItems_ItemTypes_Item_type_id",
                table: "LedgerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ItemTypes_Item_type_id",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Locations_Location_id",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_TagHistories_TagActionTypes_TagActionTypeTag_action_id",
                table: "TagHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TagHistories_TagActionTypes_Tag_action_id",
                table: "TagHistories");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_LedgerItems_Item_type_id",
                table: "LedgerItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagActionTypes",
                table: "TagActionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_Item_type_id",
                table: "Stocks");

            migrationBuilder.RenameTable(
                name: "TagActionTypes",
                newName: "TagActionType");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stock");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_Location_id",
                table: "Stock",
                newName: "IX_Stock_Location_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagActionType",
                table: "TagActionType",
                column: "Tag_action_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Stock_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Locations_Location_id",
                table: "Stock",
                column: "Location_id",
                principalTable: "Locations",
                principalColumn: "Location_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TagHistories_TagActionType_TagActionTypeTag_action_id",
                table: "TagHistories",
                column: "TagActionTypeTag_action_id",
                principalTable: "TagActionType",
                principalColumn: "Tag_action_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagHistories_TagActionType_Tag_action_id",
                table: "TagHistories",
                column: "Tag_action_id",
                principalTable: "TagActionType",
                principalColumn: "Tag_action_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
