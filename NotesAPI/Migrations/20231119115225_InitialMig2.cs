using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NotesAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Description", "Title", "created_at" },
                values: new object[,]
                {
                    { 1, "Buy milk, bread and tea", "Shopping", new DateTime(2023, 11, 19, 13, 52, 25, 124, DateTimeKind.Local).AddTicks(9444) },
                    { 2, "finish hw", "School", new DateTime(2023, 11, 19, 13, 52, 25, 124, DateTimeKind.Local).AddTicks(9537) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
