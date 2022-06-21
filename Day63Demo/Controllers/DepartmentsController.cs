using Microsoft.AspNetCore.Mvc;
using Day63Demo.Data.Services;
using Day63Demo.Data.ViewModels;

namespace Day63Demo.Controllers;

public class DepartmentsController : Controller
{
    private readonly IDepartmentsService _departmentsService;

    public DepartmentsController(IDepartmentsService departmentsService)
    {
        _departmentsService = departmentsService;
    }

    // GET: Departments
    public async Task<IActionResult> Index()
    {
        var departments = await _departmentsService.GetAllAsync();
        return View(departments);

    }

    // GET: Departments/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var department = await _departmentsService.GetByIdAsync((int)id);

        if (department == null)
            return NotFound();

        return View(department);
    }

    // GET: Departments/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Departments/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DepartmentViewModel department)
    {
        if (ModelState.IsValid)
        {
            await _departmentsService.CreateAsync(department);
            return RedirectToAction(nameof(Index));
        }

        return View(department);
    }
}