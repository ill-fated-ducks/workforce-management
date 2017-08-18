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
                if (context.Computer.Any())
                {
                    return;   // DB has been seeded
                }

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
                     }
                     // no future computer
                );

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
                         Budget = 18764
                     }
                );

                context.Employee.AddRange(
                     // employees
                     new Employee
                     {
                         FirstName = "John",
                         LastName = "Wayne",
                         StartDate = DateTime.Parse("1971-03-23"),
                         Supervisor = true,
                         DeptID = 2
                     },
                     new Employee
                     {
                         FirstName = "Jimmy",
                         LastName = "Dean",
                         StartDate = DateTime.Parse("1987-04-03"),
                         Supervisor = false,
                         DeptID = 1
                     },
                     new Employee
                     {
                         FirstName = "Jacques",
                         LastName = "Cousteau",
                         StartDate = DateTime.Parse("1994-05-13"),
                         Supervisor = false,
                         DeptID = 3
                     }
                 );

                context.TrainingProgram.AddRange(
                        // training programs
                        // past training program
                        new TrainingProgram
                        {
                            Name = "Doing Your Best",
                            StartDate = DateTime.Parse("2010-07-23"),
                            EndDate = DateTime.Parse("2010-07-27"),
                            MaxAttendees = 12
                        },
                    // present training program
                    new TrainingProgram
                    {
                        Name = "Excelling at Excel",
                        StartDate = DateTime.Parse("2017-08-27"),
                        EndDate = DateTime.Parse("2017-09-15"),
                        MaxAttendees = 22
                    },
                    // future training program
                    new TrainingProgram
                    {
                        Name = "Bring Your Things",
                        StartDate = DateTime.Parse("2017-12-13"),
                        EndDate = DateTime.Parse("2017-12-15"),
                        MaxAttendees = 3
                    }

                 );

                context.SaveChanges();
            }
        }
    }
}