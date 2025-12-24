using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sol_denka_stockmanagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedFieldMasterData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FieldMaster",
                columns: new[] { "Field_id", "Control_type", "Created_at", "Data_type", "Field_code", "Field_name", "Is_active", "Updated_at" },
                values: new object[,]
                {
                    { 1, "INPUT", "2025-01-01", "NUMBER", "WEIGHT", "重量", 1, "2025-01-01" },
                    { 2, "INPUT", "2025-01-01", "NUMBER", "LENGTH", "長さ", 1, "2025-01-01" },
                    { 3, "INPUT", "2025-01-01", "NUMBER", "THICKNESS", "厚さ", 1, "2025-01-01" },
                    { 4, "INPUT", "2025-01-01", "NUMBER", "WIDTH", "巾", 1, "2025-01-01" },
                    { 5, "INPUT", "2025-01-01", "NUMBER", "QUANTITY", "数量", 1, "2025-01-01" },
                    { 6, "DROPDOWN", "2025-01-01", "TEXT", "WINDER", "巻取機", 1, "2025-01-01" },
                    { 7, "INPUT", "2025-01-01", "TEXT", "OCCURRENCE_REASON", "発生理由", 1, "2025-01-01" },
                    { 8, "INPUT", "2025-01-01", "TEXT", "LOT_NO", "Lot No", 1, "2025-01-01" },
                    { 9, "DATETIME_PICKER", "2025-01-01", "DATETIME", "OCCURRED_AT", "発生日時", 1, "2025-01-01" },
                    { 10, "DATETIME_PICKER", "2025-01-01", "DATETIME", "PROCESSED_AT", "処理日時", 1, "2025-01-01" },
                    { 11, "DROPDOWN", "2025-01-01", "TEXT", "LOCATION", "保管場所", 1, "2025-01-01" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FieldMaster",
                keyColumn: "Field_id",
                keyValue: 11);
        }
    }
}
