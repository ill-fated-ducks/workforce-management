using Bangazon_Workforce_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Workforce_Management.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        
        public IEnumerable<TrainingProgram> Programs { get; set; }

        public HomePageViewModel(IEnumerable<Employee> employees, IEnumerable<TrainingProgram> programs)
        {
            Employees = employees;
            Programs = programs;
        }
    }
}
