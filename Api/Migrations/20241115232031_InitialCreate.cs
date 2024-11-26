using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "PR" },
                    { 4, "Finance" },
                    { 5, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john@gmail.com", "John", 0, "Smith", "images/john.png" },
                    { 2, new DateTime(1996, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "daniel@gmail.com", "Daniel", 0, "Rabbit", "images/daniel.png" },
                    { 3, new DateTime(1985, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "leonard@gmail.com", "Leonard", 0, "White", "images/leonard.png" },
                    { 4, new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "rafael@gmail.com", "Rafael", 0, "Singer", "images/rafael.png" },
                    { 5, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jane@gmail.com", "Jane", 1, "Hobbit", "images/jane.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
