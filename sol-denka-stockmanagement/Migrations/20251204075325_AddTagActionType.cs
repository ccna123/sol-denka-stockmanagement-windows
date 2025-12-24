using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class AddTagActionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagActionTypeTag_action_id",
                table: "TagHistories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TagActionType",
                columns: table => new
                {
                    Tag_action_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Action_code = table.Column<string>(type: "TEXT", nullable: false),
                    Action_name = table.Column<string>(type: "TEXT", nullable: false),
                    Is_active = table.Column<int>(type: "INTEGER", nullable: false),
                    Created_at = table.Column<string>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagActionType", x => x.Tag_action_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagHistories_Tag_action_id",
                table: "TagHistories",
                column: "Tag_action_id");

            migrationBuilder.CreateIndex(
                name: "IX_TagHistories_TagActionTypeTag_action_id",
                table: "TagHistories",
                column: "TagActionTypeTag_action_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagHistories_TagActionType_TagActionTypeTag_action_id",
                table: "TagHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TagHistories_TagActionType_Tag_action_id",
                table: "TagHistories");

            migrationBuilder.DropTable(
                name: "TagActionType");

            migrationBuilder.DropIndex(
                name: "IX_TagHistories_Tag_action_id",
                table: "TagHistories");

            migrationBuilder.DropIndex(
                name: "IX_TagHistories_TagActionTypeTag_action_id",
                table: "TagHistories");

            migrationBuilder.DropColumn(
                name: "TagActionTypeTag_action_id",
                table: "TagHistories");
        }
    }
}
