using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Workforce_Management.Models.ViewModel
{
    public class EmployeeEditVM
    {
        public Employee Employee { get; set; }
        public List<TrainingProgram> TrainingPrograms { get; set; }
        public List<Computer> Computers { get; set; }
        public EmployeeEditVM()
        {
            TrainingPrograms = new List<TrainingProgram>();
            Computers = new List<Computer>();
            ComputerEmployee = new ComputerEmployee();
            TrainingProgramEmployee = new TrainingProgramEmployee();
        }
        public int ComputerID { get; set; }
        public int DepID { get; set; }
        public ComputerEmployee ComputerEmployee { get; set; }
        public TrainingProgramEmployee TrainingProgramEmployee { get; set; }
    }
}
