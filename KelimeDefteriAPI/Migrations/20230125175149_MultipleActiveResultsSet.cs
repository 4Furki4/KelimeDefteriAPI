using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KelimeDefteriAPI.Migrations
{
    /// <inheritdoc />
    public partial class MultipleActiveResultsSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Created",
                value: new DateTime(2023, 1, 25, 20, 51, 49, 556, DateTimeKind.Local).AddTicks(7215));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Created",
                value: new DateTime(2023, 1, 18, 17, 2, 9, 113, DateTimeKind.Local).AddTicks(1371));
        }
    }
}
