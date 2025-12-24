using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LedgerItems",
                columns: table => new
                {
                    LedgerItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsInStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: true),
                    Grade = table.Column<string>(type: "TEXT", nullable: false),
                    SpecificGravity = table.Column<int>(type: "INTEGER", nullable: true),
                    Thickness = table.Column<int>(type: "INTEGER", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Length = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    WinderInfo = table.Column<string>(type: "TEXT", nullable: false),
                    MisrollReason = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerItems", x => x.LedgerItemId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LedgerItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    Epc = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_LedgerItems_LedgerItemId",
                        column: x => x.LedgerItemId,
                        principalTable: "LedgerItems",
                        principalColumn: "LedgerItemId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Epc",
                table: "Tags",
                column: "Epc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_LedgerItemId",
                table: "Tags",
                column: "LedgerItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "LedgerItems");
        }
    }
}
