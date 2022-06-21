using Day63Demo.Controllers;
using Day63Demo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Day63Demo.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Nationality> Nationalities { get; set; } = null!;

    public DbSet<TestDataModel> TestDataModel { get; set; } = null!;
}