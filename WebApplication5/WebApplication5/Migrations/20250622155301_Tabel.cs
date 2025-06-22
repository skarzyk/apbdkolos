using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class Tabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Nurseries",
                columns: table => new
                {
                    NurseryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EstablishedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurseries", x => x.NurseryId);
                });

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "integer", nullable: false),
                    Employee = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => new { x.Employee, x.BatchId });
                });

            migrationBuilder.CreateTable(
                name: "Seedling_Batch",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NurseryId = table.Column<int>(type: "integer", nullable: false),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    SowndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReadyDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seedling_Batch", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Tree_Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LatinName = table.Column<string>(type: "text", nullable: false),
                    GrowthTimeInYears = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree_Species", x => x.SpeciesId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, "John", new DateOnly(2020, 1, 15), "Doe" },
                    { 2, "Jokky", new DateOnly(2020, 2, 15), "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Nurseries",
                columns: new[] { "NurseryId", "EstablishedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateOnly(2015, 3, 10), "Green Haven" },
                    { 2, new DateOnly(2015, 8, 10), "Haven" }
                });

            migrationBuilder.InsertData(
                table: "Responsibles",
                columns: new[] { "BatchId", "Employee", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Manager" },
                    { 2, 2, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Seedling_Batch",
                columns: new[] { "BatchId", "NurseryId", "Quantity", "ReadyDate", "SowndDate", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 1, 1000, new DateOnly(2023, 6, 1), new DateOnly(2023, 1, 1), 1 },
                    { 2, 2, 700, new DateOnly(2023, 9, 1), new DateOnly(2023, 5, 1), 2 }
                });

            migrationBuilder.InsertData(
                table: "Tree_Species",
                columns: new[] { "SpeciesId", "GrowthTimeInYears", "LatinName" },
                values: new object[,]
                {
                    { 1, 1, "Oak" },
                    { 2, 2, "Burak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Nurseries");

            migrationBuilder.DropTable(
                name: "Responsibles");

            migrationBuilder.DropTable(
                name: "Seedling_Batch");

            migrationBuilder.DropTable(
                name: "Tree_Species");
        }
    }
}
