using Bangazon_Workforce_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Workforce_Management.ViewModels
{
    public class TrainingEmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public TrainingProgram Program { get; set; }
        
        /*public TrainingEmployeeViewModel(IEnumerable<Employee> employees, TrainingProgram program)
        {
            Program = program;
            Employees = employees;
        }*/
    }
}
