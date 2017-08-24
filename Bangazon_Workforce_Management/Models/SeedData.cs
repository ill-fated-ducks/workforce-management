using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Bangazon_Workforce_Management.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Bangazon_Workforce_ManagementContext(
                serviceProvider.GetRequiredService<DbContextOptions<Bangazon_Workforce_ManagementContext>>()))
            {
                // Look for any computers as a check to see if db is already seeded.

                //if (context.Computer.Any())
                //{
                //    return;   // DB has been seeded
                //}

                context.Computer.AddRange(

                     // present computer
                     new Computer
                     {
                         PurchaseDate = DateTime.Parse("2008-02-23"),
                         DecomissionDate = null,
                         Manufacturer = "Dell",
                         Make = "Inspiron"
                     },
                     // past computer
                     new Computer
                     {
                         PurchaseDate = DateTime.Parse("2006-02-23"),
                         DecomissionDate = null,
                         Manufacturer = "Apple",
                         Make = "Macbook"
                     },
                     new Computer
                     {
                         PurchaseDate = DateTime.Parse("2009-02-23"),
                         DecomissionDate = null,
                         Manufacturer = "Acer",
                         Make = "Aspire"
                     },
                     new Computer
                     {
                         PurchaseDate = DateTime.Parse("2011-02-23"),
                         DecomissionDate = null,
                         Manufacturer = "Acer",
                         Make = "Aspire4"
                     },
                     new Computer
                     {
                         PurchaseDate = DateTime.Parse("2008-02-23"),
                         DecomissionDate = null,
                         Manufacturer = "ASUS",
                         Make = "Zenbook"
                     },
                     new Computer
                     {
                         PurchaseDate = DateTime.Parse("2010-02-23"),
                         DecomissionDate = null,
                         Manufacturer = "Toshiba",
                         Make = "Space"
                     }

                     // no future computer
                );
                context.SaveChanges();
                context.Department.AddRange(
                     // departments all present
                     new Department
                     {
                         DeptName = "Marketing",
                         Budget = 100987
                     },
                     new Department
                     {
                         DeptName = "Accounting",
                         Budget = 9876
                     },
                     new Department
                     {
                         DeptName = "R&D",
                         Budget = 22764
                     },
                     new Department
                     {
                         DeptName = "Finance",
                         Budget = 19764
                     },
                     new Department
                     {
                         DeptName = "Sports",
                         Budget = 38721
                     }
                );
                context.SaveChanges();
                context.Employee.AddRange(
                     // employees
                     new Employee
                     {
                         FirstName = "John",
                         LastName = "Wayne",
                         StartDate = DateTime.Parse("1971-03-23"),
                         Supervisor = true,
                         DeptID = context.Department.First(s => s.DeptName == "Marketing").DeptID,
                     },
                     new Employee
                     {
                         FirstName = "Jimmy",
                         LastName = "Dean",
                         StartDate = DateTime.Parse("1987-04-03"),
                         Supervisor = false,
                         DeptID = context.Department.First(s => s.DeptName == "Accounting").DeptID,
                     },
                     new Employee
                     {
                         FirstName = "Jacques",
                         LastName = "Cousteau",
                         StartDate = DateTime.Parse("1991-05-13"),
                         Supervisor = false,
                         DeptID = context.Department.First(s => s.DeptName == "R&D").DeptID,
                     },
                     new Employee
                     {
                         FirstName = "Drake",
                         LastName = "Cortez",
                         StartDate = DateTime.Parse("1999-05-13"),
                         Supervisor = false,
                         DeptID = context.Department.First(s => s.DeptName == "R&D").DeptID,
                     },
                     new Employee
                     {
                         FirstName = "Dominic",
                         LastName = "Verton",
                         StartDate = DateTime.Parse("1998-05-13"),
                         Supervisor = false,
                         DeptID = context.Department.First(s => s.DeptName == "R&D").DeptID,
                     },
                     new Employee
                     {
                         FirstName = "Wakka",
                         LastName = "Flokka",
                         StartDate = DateTime.Parse("1995-05-13"),
                         Supervisor = false,
                         DeptID = context.Department.First(s => s.DeptName == "R&D").DeptID,
                     },
                     new Employee
                     {
                         FirstName = "Smith",
                         LastName = "Havier",
                         StartDate = DateTime.Parse("1996-05-13"),
                         Supervisor = false,
                         DeptID = context.Department.First(s => s.DeptName == "R&D").DeptID,
                     }

                 );
                context.SaveChanges();

                context.TrainingProgram.AddRange(
                    // training programs
                    // past training program
                    new TrainingProgram
                    {
                        Name = "Doing Your Best",
                        Description = "The best ever training program",
                        StartDate = DateTime.Parse("2010-07-23"),
                        EndDate = DateTime.Parse("2010-07-27"),
                        MaxAttendees = 12
                    },
                    // present training program
                    new TrainingProgram
                    {
                        Name = "Excelling at Excel",
                        Description = "Second best ever training program",
                        StartDate = DateTime.Parse("2017-08-27"),
                        EndDate = DateTime.Parse("2017-09-15"),
                        MaxAttendees = 22
                    },
                    // future training program
                    new TrainingProgram
                    {
                        Name = "Bring Your Things",
                        Description = "Third best ever training program",
                        StartDate = DateTime.Parse("2017-12-13"),
                        EndDate = DateTime.Parse("2017-12-15"),
                        MaxAttendees = 3
                    }

                 );
                context.SaveChanges();

                context.ComputerEmployee.AddRange(
                    // computer employee joins
                    // past assigned
                    new ComputerEmployee
                    {
                        ComputerID = context.Computer.First(s => s.Make == "Macbook").ComputerID,
                        EmployeeID = context.Employee.First(s => s.FirstName == "John").EmployeeID,
                        End = DateTime.Parse("2011-12-15"),
                        Start = DateTime.Parse("2000-12-13")
                    },
                    // present assigned
                    new ComputerEmployee
                    {
                        ComputerID = context.Computer.First(s => s.Make == "Inspiron").ComputerID,
                        EmployeeID = context.Employee.First(s => s.FirstName == "Jimmy").EmployeeID,
                        End = DateTime.Parse("2011-12-15"),
                        Start = DateTime.Parse("2017-12-13")

                    },
                    new ComputerEmployee
                    {
                        ComputerID = context.Computer.First(s => s.Make == "Aspire").ComputerID,
                        EmployeeID = context.Employee.First(s => s.FirstName == "Jacques").EmployeeID,
                        End = null,
                        Start = DateTime.Parse("2016-12-13")
                    },
                    new ComputerEmployee
                    {
                        ComputerID = context.Computer.First(s => s.Make == "Zenbook").ComputerID,
                        EmployeeID = context.Employee.First(s => s.FirstName == "Drake").EmployeeID,
                        End = null,
                        Start = DateTime.Parse("2015-12-13")
                    },
                    new ComputerEmployee
                    {
                        ComputerID = context.Computer.First(s => s.Make == "Aspire4").ComputerID,
                        EmployeeID = context.Employee.First(s => s.FirstName == "Dominic").EmployeeID,
                        End = null,
                        Start = DateTime.Parse("2014-12-13")
                    },
                    new ComputerEmployee
                    {
                        ComputerID = context.Computer.First(s => s.Make == "Space").ComputerID,
                        EmployeeID = context.Employee.First(s => s.FirstName == "Wakka").EmployeeID,
                        End = null,
                        Start = DateTime.Parse("2016-09-13")
                    }
                // no future assigned

                );
                context.SaveChanges();
                context.TrainingProgramEmployee.AddRange(
                     // present training program joins
                     new TrainingProgramEmployee
                     {
                         TrainingProgramID = context.TrainingProgram.First(s => s.Name == "Excelling at Excel").TrainingProgramID,
                         EmployeeID = context.Employee.First(s => s.FirstName == "John").EmployeeID,
                     },
                     new TrainingProgramEmployee
                     {
                         TrainingProgramID = context.TrainingProgram.First(s => s.Name == "Bring Your Things").TrainingProgramID,
                         EmployeeID = context.Employee.First(s => s.FirstName == "Jimmy").EmployeeID,
                     }
                );

                context.SaveChanges();
            }
        }
    }
}