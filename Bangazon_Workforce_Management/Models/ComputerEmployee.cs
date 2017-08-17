using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Workforce_Management.Models
{
    public class ComputerEmployee
    {
        [Key]
        public int ComputerEmployeeID { get; set; }

        [Required]
        public int EmployeeID { get; set; }
        
        public Employee Employee { get; set; }
        
        [Required]
        public int ComputerID { get; set; }

        public Computer Computer { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
