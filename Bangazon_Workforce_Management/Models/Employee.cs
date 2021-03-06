﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Bangazon_Workforce_Management.Models;

namespace Bangazon_Workforce_Management.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        public bool Supervisor { get; set; }
        
        [Required]
        [Display(Name = "Department")]
        public int DeptID { get; set; }

        public Department Department { get; set; }

        public ICollection<ComputerEmployee> ComputerEmployee { get; set; }

        public ICollection<TrainingProgramEmployee> TrainingProgramEmployee { get; set; }
    }
}
