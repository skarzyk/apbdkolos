using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class TableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Employee",
                table: "Responsibles",
                newName: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seedling_Batch_NurseryId",
                table: "Seedling_Batch",
                column: "NurseryId");

            migrationBuilder.CreateIndex(
                name: "IX_Seedling_Batch_SpeciesId",
                table: "Seedling_Batch",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_BatchId",
                table: "Responsibles",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_Employees_EmployeeId",
                table: "Responsibles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_Seedling_Batch_BatchId",
                table: "Responsibles",
                column: "BatchId",
                principalTable: "Seedling_Batch",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seedling_Batch_Nurseries_NurseryId",
                table: "Seedling_Batch",
                column: "NurseryId",
                principalTable: "Nurseries",
                principalColumn: "NurseryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seedling_Batch_Tree_Species_SpeciesId",
                table: "Seedling_Batch",
                column: "SpeciesId",
                principalTable: "Tree_Species",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_Employees_EmployeeId",
                table: "Responsibles");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_Seedling_Batch_BatchId",
                table: "Responsibles");

            migrationBuilder.DropForeignKey(
                name: "FK_Seedling_Batch_Nurseries_NurseryId",
                table: "Seedling_Batch");

            migrationBuilder.DropForeignKey(
                name: "FK_Seedling_Batch_Tree_Species_SpeciesId",
                table: "Seedling_Batch");

            migrationBuilder.DropIndex(
                name: "IX_Seedling_Batch_NurseryId",
                table: "Seedling_Batch");

            migrationBuilder.DropIndex(
                name: "IX_Seedling_Batch_SpeciesId",
                table: "Seedling_Batch");

            migrationBuilder.DropIndex(
                name: "IX_Responsibles_BatchId",
                table: "Responsibles");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Responsibles",
                newName: "Employee");
        }
    }
}
