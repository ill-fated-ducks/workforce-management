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
        public TrainingProgram TrainingProgram { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
