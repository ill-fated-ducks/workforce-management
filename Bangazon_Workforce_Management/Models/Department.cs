using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bangazon.Models
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
    public double Budget { get; set; }
  }
}
