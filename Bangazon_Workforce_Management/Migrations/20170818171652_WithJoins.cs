using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bangazon_Workforce_Management.Migrations
{
    public partial class WithJoins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.ForeignKey(
                        name: "FK_TrainingProgramEmployee_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingProgramEmployee_TrainingProgram_TrainingProgramID",
                        column: x => x.TrainingProgramID,
                        principalTable: "TrainingProgram",
                        principalColumn: "TrainingProgramID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerEmployee_ComputerID",
                table: "ComputerEmployee",
                column: "ComputerID");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerEmployee_EmployeeID",
                table: "ComputerEmployee",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramEmployee_EmployeeID",
                table: "TrainingProgramEmployee",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramEmployee_TrainingProgramID",
                table: "TrainingProgramEmployee",
                column: "TrainingProgramID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerEmployee");

            migrationBuilder.DropTable(
                name: "TrainingProgramEmployee");
        }
    }
}
