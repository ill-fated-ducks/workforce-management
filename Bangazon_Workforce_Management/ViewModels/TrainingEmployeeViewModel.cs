﻿using Bangazon_Workforce_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Workforce_Management.ViewModels
{
    //This class was authored by Jordan Dhaenens
    //This class represents a join table of Training Programs and Employees
    public class TrainingEmployeeViewModel
    {
        public IEnumerable<TrainingProgramEmployee> TrainingProgramEmployees { get; set; }
        public TrainingProgram Program { get; set; }
        
        public TrainingEmployeeViewModel(IEnumerable<TrainingProgramEmployee> employees, TrainingProgram program)
        {
            Program = program;
            TrainingProgramEmployees = employees;
        }
    }
}
