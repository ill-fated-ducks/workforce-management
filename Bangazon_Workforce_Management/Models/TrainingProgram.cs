using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Workforce_Management.Models
{
    public class TrainingProgram
    {
        [Key]
        public int TrainingProgramID { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }

        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int MaxAttendees { get; set; }

        public ICollection<TrainingProgramEmployee> TrainingProgramEmployee { get; set; }
    }
}
