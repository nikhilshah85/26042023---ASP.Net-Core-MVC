using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace employeeManagement.Models.EF;

public partial class EmpInfo
{

    [Required(ErrorMessage ="Please Provide Employee Number")]
    [Display(Name ="No")]
    public int EmpNo { get; set; }

    [Required(ErrorMessage = "Name is Mandatory")]
    [Display(Name ="First Name")]
    [StringLength(20,MinimumLength =3,ErrorMessage ="Name should be between 3 and 20 Characters only")]
    public string EmpName { get; set; } = null!;


    [Required(ErrorMessage ="Designation cannot be left blank")]
    [Display(Name = "Works As")]
    public string EmpDesignation { get; set; } = null!;


    [System.ComponentModel.DataAnnotations.Range(12000,50000,ErrorMessage ="Salary should be between 12K and 50K only")]
    [Display(Name ="Montly Pay")]
    public int EmpSalary { get; set; }

    [Required]
    public int EmpDeptNo { get; set; }

    public bool EmpIsPermenant { get; set; }

    public virtual DeptInfo EmpDeptNoNavigation { get; set; } = null!;
}
