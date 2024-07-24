using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CampusApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnrolled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "History" },
                    { 2, "Math" },
                    { 3, "War" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthdate", "Email", "IsEnrolled", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ragnartheboss@gmail.com", false, "The Red", "Ragnar" },
                    { 2, new DateTime(1492, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TheLioness78@gmail.com", true, "The Lioness", "Mjoll" },
                    { 3, new DateTime(1485, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "SecretBlade@yahoo.com", false, "The Blade", "Delphine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
