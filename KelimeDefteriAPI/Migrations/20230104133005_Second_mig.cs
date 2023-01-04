using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelimeDefteriAPI.Migrations
{
    /// <inheritdoc />
    public partial class Secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Definitions_Words_WordId",
                table: "Definitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Records_RecordId",
                table: "Words");

            migrationBuilder.AlterColumn<long>(
                name: "RecordId",
                table: "Words",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "WordId",
                table: "Definitions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Created", "Modified" },
                values: new object[] { -1L, new DateTime(2023, 1, 4, 16, 30, 5, 690, DateTimeKind.Local).AddTicks(3061), null });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Definitions_Words_WordId",
                table: "Definitions",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Records_RecordId",
                table: "Words",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Definitions_Words_WordId",
                table: "Definitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Records_RecordId",
                table: "Words");

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

            migrationBuilder.AlterColumn<long>(
                name: "RecordId",
                table: "Words",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "WordId",
                table: "Definitions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Definitions_Words_WordId",
                table: "Definitions",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Records_RecordId",
                table: "Words",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id");
        }
    }
}
