using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bangazon_Workforce_Management.Models;

namespace Bangazon_Workforce_Management.Models
{
    public class Bangazon_Workforce_ManagementContext : DbContext
    {
        public Bangazon_Workforce_ManagementContext (DbContextOptions<Bangazon_Workforce_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Bangazon_Workforce_Management.Models.Computer> Computer { get; set; }

        public DbSet<Bangazon_Workforce_Management.Models.Department> Department { get; set; }

        public DbSet<Bangazon_Workforce_Management.Models.TrainingProgram> TrainingProgram { get; set; }

        public DbSet<Bangazon_Workforce_Management.Models.Employee> Employee { get; set; }
    }
}
