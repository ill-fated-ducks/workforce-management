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
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DecomissionDate { get; set; }

        [Required]
        [StringLength(40)]
        public string Manufacturer { get; set; }
        
        [Required]
        [StringLength(40)]
        public string Make { get; set; }

        public ICollection<ComputerEmployee> ComputerEmployee { get; set; }

    }
}
