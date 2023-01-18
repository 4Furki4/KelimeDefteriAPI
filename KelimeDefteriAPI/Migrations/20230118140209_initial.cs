using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KelimeDefteriAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Definitions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Definitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Definitions_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Created", "Modified" },
                values: new object[] { -1L, new DateTime(2023, 1, 18, 17, 2, 9, 113, DateTimeKind.Local).AddTicks(1371), null });

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

            migrationBuilder.CreateIndex(
                name: "IX_Definitions_WordId",
                table: "Definitions",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "CreatedIndex",
                table: "Records",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Words_RecordId",
                table: "Words",
                column: "RecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Definitions");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
