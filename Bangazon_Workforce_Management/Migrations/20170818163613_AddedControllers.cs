using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bangazon_Workforce_Management.Migrations
{
    public partial class AddedControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingProgramEmployeeID",
                table: "TrainingProgram",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingProgramEmployeeID",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComputerEmployee",
                columns: table => new
                {
                    ComputerEmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComputerID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerEmployee", x => x.ComputerEmployeeID);
                    table.ForeignKey(
                        name: "FK_ComputerEmployee_Computer_ComputerID",
                        column: x => x.ComputerID,
                        principalTable: "Computer",
                        principalColumn: "ComputerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerEmployee_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgramEmployee",
                columns: table => new
                {
                    TrainingProgramEmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    TrainingProgramID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgramEmployee", x => x.TrainingProgramEmployeeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgram_TrainingProgramEmployeeID",
                table: "TrainingProgram",
                column: "TrainingProgramEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TrainingProgramEmployeeID",
                table: "Employee",
                column: "TrainingProgramEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerEmployee_ComputerID",
                table: "ComputerEmployee",
                column: "ComputerID");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerEmployee_EmployeeID",
                table: "ComputerEmployee",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_TrainingProgramEmployee_TrainingProgramEmployeeID",
                table: "Employee",
                column: "TrainingProgramEmployeeID",
                principalTable: "TrainingProgramEmployee",
                principalColumn: "TrainingProgramEmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingProgram_TrainingProgramEmployee_TrainingProgramEmployeeID",
                table: "TrainingProgram",
                column: "TrainingProgramEmployeeID",
                principalTable: "TrainingProgramEmployee",
                principalColumn: "TrainingProgramEmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_TrainingProgramEmployee_TrainingProgramEmployeeID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingProgram_TrainingProgramEmployee_TrainingProgramEmployeeID",
                table: "TrainingProgram");

            migrationBuilder.DropTable(
                name: "ComputerEmployee");

            migrationBuilder.DropTable(
                name: "TrainingProgramEmployee");

            migrationBuilder.DropIndex(
                name: "IX_TrainingProgram_TrainingProgramEmployeeID",
                table: "TrainingProgram");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TrainingProgramEmployeeID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TrainingProgramEmployeeID",
                table: "TrainingProgram");

            migrationBuilder.DropColumn(
                name: "TrainingProgramEmployeeID",
                table: "Employee");
        }
    }
}
