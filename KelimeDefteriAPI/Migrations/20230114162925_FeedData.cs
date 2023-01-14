using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelimeDefteriAPI.Migrations
{
    /// <inheritdoc />
    public partial class FeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Created", "Modified" },
                values: new object[] { -1L, new DateTime(2023, 1, 14, 19, 29, 25, 617, DateTimeKind.Local).AddTicks(8347), null });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Name", "RecordId" },
                values: new object[,]
                {
                    { -4L, "TEST4", -1L },
                    { -3L, "TEST3", -1L },
                    { -2L, "TEST2", -1L },
                    { -1L, "TEST1", -1L }
                });

            migrationBuilder.InsertData(
                table: "Definitions",
                columns: new[] { "Id", "Description", "DescriptionType", "WordId" },
                values: new object[,]
                {
                    { -8L, "test4description", "test4descriptionType", -4L },
                    { -7L, "test4description", "test4descriptionType", -4L },
                    { -6L, "test3description", "test3descriptionType", -3L },
                    { -5L, "test3description", "test3descriptionType", -3L },
                    { -4L, "test2description", "test2descriptionType", -2L },
                    { -3L, "test2description", "test2descriptionType", -2L },
                    { -2L, "test1description", "test1descriptionType", -1L },
                    { -1L, "test1description", "test1descriptionType", -1L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Definitions",
                keyColumn: "Id",
                keyValue: -8L);

            migrationBuilder.DeleteData(
                table: "Definitions",
                keyColumn: "Id",
                keyValue: -7L);

            migrationBuilder.DeleteData(
                table: "Definitions",
                keyColumn: "Id",
                keyValue: -6L);

            migrationBuilder.DeleteData(
                table: "Definitions",
                keyColumn: "Id",
                keyValue: -5L);

            migrationBuilder.DeleteData(
                table: "Definitions",
                keyColumn: "Id",
                keyValue: -4L);

            migrationBuilder.DeleteData(
                table: "Definitions",
                keyColumn: "Id",
                keyValue: -3L);

            migrationBuilder.DeleteData(
                table: "Definitions",
                keyColumn: "Id",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "Definitions",
                keyColumn: "Id",
                keyValue: -1L);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: -4L);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: -3L);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: -1L);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "Id",
                keyValue: -1L);
        }
    }
}
