using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI___JWT_Authentication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(name: "User Name", type: "VARCHAR(35)", maxLength: 35, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Date = table.Column<DateOnly>(type: "DATE", nullable: false),
                    TemperatureC = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false, defaultValue: 0m),
                    Summary = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User Name", "Password" },
                values: new object[,]
                {
                    { "Abdalkreem", "12121221" },
                    { "Islam", "121571021" },
                    { "Mohammed", "129763221" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
