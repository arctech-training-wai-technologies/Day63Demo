using System.ComponentModel.DataAnnotations;

namespace Day63Demo.Data.ViewModels;

public class DepartmentViewModel
{
    public int Id { get; set; }

    [Display(Name = "Department")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}

