using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class inicalizBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherNow",
                columns: new[] { "Id", "Date", "Temperature" },
                values: new object[] { 1, new DateTime(2023, 5, 9, 9, 15, 9, 87, DateTimeKind.Local).AddTicks(363), 0.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherNow",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
