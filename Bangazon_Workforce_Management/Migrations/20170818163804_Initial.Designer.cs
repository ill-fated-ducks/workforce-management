using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bangazon_Workforce_Management.Models;

namespace Bangazon_Workforce_Management.Migrations
{
    [DbContext(typeof(Bangazon_Workforce_ManagementContext))]
    [Migration("20170818163804_Initial")]
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
                        .IsRequired();

                    b.Property<string>("Manufacturer")
                        .IsRequired();

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("ComputerID");

                    b.ToTable("Computer");
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
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

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

            modelBuilder.Entity("Bangazon_Workforce_Management.Models.Employee", b =>
                {
                    b.HasOne("Bangazon_Workforce_Management.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
