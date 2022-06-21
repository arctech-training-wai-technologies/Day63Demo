using Microsoft.AspNetCore.Mvc;
using Day63Demo.Data.Services;
using Day63Demo.Data.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day63Demo.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeesService _employeesService;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(IEmployeesService employeesService, ILogger<EmployeesController> logger)
    {
        _employeesService = employeesService;
        _logger = logger;
    }

    // GET: Employees
    public async Task<IActionResult> Index()
    {
        var employees = await _employeesService.GetAllAsync();
        return View(employees);

    }

    // GET: Employees/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var employee = await _employeesService.GetByIdAsync((int)id);

        if (employee == null)
            return NotFound();

        return View(employee);
    }

    // GET: Employees/Create
    public async Task<IActionResult> Create()
    {
        ViewData["DepartmentList"] = await GetSelectListDepartmentAsync();
        ViewData["NationalityList"] = await GetSelectListNationalityAsync();

        return View();
    }

    // POST: Employees/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeViewModel employee)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _employeesService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Some Error occurred while creating employee. for employee id = {Name}", employee.Name);

                ModelState.AddModelError(string.Empty, "Cannot create Employee at this time");

                return View(employee);
            }
        }

        ViewData["DepartmentList"] = await GetSelectListDepartmentAsync();
        ViewData["NationalityList"] = await GetSelectListNationalityAsync();

        return View(employee);
    }

    private async Task<SelectList> GetSelectListDepartmentAsync()
    {
        _logger.LogInformation("Started GetSelectListDepartmentAsync");
        return new SelectList(
            await _employeesService.GetDepartmentForDropDownAsync(),
            nameof(DropDownViewModel.Id), nameof(DropDownViewModel.Text));
    }

    private async Task<SelectList> GetSelectListNationalityAsync()
    {
        _logger.LogInformation("Started GetSelectListNationalityAsync");

        return new SelectList(
            await _employeesService.GetNationalityForDropDownAsync(),
            nameof(DropDownViewModel.Id), nameof(DropDownViewModel.Text));
    }
}