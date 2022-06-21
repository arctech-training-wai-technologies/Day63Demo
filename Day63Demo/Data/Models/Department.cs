using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day63Demo.Data.Models;

public class Department
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Unicode(false)]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Unicode(false)]
    [StringLength(500)]
    public string? Description { get; set; }
}

