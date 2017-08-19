using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bangazon_Workforce_Management.Models;

namespace Bangazon_Workforce_Management.Migrations
{
    [DbContext(typeof(Bangazon_Workforce_ManagementContext))]
    [Migration("20170819004431_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.Computer", b =>
                {
                    b.Property<int>("ComputerID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DecomissionDate");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("ComputerID");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.ComputerEmployee", b =>
                {
                    b.Property<int>("ComputerEmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComputerID");

                    b.Property<int>("EmployeeID");

                    b.Property<DateTime>("End");

                    b.Property<DateTime>("Start");

                    b.HasKey("ComputerEmployeeID");

                    b.HasIndex("ComputerID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("ComputerEmployee");
                });

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.Department", b =>
                {
                    b.Property<int>("DeptID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Budget");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("DeptID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DeptID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("Supervisor");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DeptID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.TrainingProgram", b =>
                {
                    b.Property<int>("TrainingProgramID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("MaxAttendees")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("TrainingProgramID");

                    b.ToTable("TrainingProgram");
                });

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.TrainingProgramEmployee", b =>
                {
                    b.Property<int>("TrainingProgramEmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<int>("TrainingProgramID");

                    b.HasKey("TrainingProgramEmployeeID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TrainingProgramID");

                    b.ToTable("TrainingProgramEmployee");
                });

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.ComputerEmployee", b =>
                {
                    b.HasOne("Bangazon_Workforce_Management.Models.Computer", "Computer")
                        .WithMany("ComputerEmployee")
                        .HasForeignKey("ComputerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bangazon_Workforce_Management.Models.Employee", "Employee")
                        .WithMany("ComputerEmployee")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.Employee", b =>
                {
                    b.HasOne("Bangazon_Workforce_Management.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.TrainingProgramEmployee", b =>
                {
                    b.HasOne("Bangazon_Workforce_Management.Models.Employee", "Employee")
                        .WithMany("TrainingProgramEmployee")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bangazon_Workforce_Management.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("TrainingProgramEmployee")
                        .HasForeignKey("TrainingProgramID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
