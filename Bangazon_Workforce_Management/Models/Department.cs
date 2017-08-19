using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bangazon_Workforce_Management.Models
{
  public class Department
  {
    [Key]
    public int DeptID {get;set;}

    [Required]
    [StringLength(55)]
    [Display(Name="Department Name")]
    public string DeptName { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public double Budget { get; set; }
  }
}
