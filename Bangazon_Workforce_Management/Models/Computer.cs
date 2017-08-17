using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Workforce_Management.Models
{
    public class Computer
    {
        [Key]
        public int ComputerID { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        public DateTime? DecomissionDate { get; set; }

        [Required]
        public string Manufacturer { get; set; }
        
        [Required]
        public string Make { get; set; }

    }
}
