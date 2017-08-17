using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Workforce_Management.Models
{
    public class TrainingProgramEmployee
    {
        [Key]
        public int TrainingProgramEmployeeID { get; set; }
        [Required]
        public  int TrainingProgramID { get; set; }
        public ICollection<TrainingProgram> Program { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
