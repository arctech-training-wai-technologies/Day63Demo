using Day63Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Day63Demo.Data;
using Microsoft.EntityFrameworkCore;

namespace Day63Demo.Controllers
{
    public class TestDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }


    public class TestViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
    }


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, ApplicationDbContext db)
        {
            _logger = logger;
            _mapper = mapper;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {

            //var testViewModel = testDataModel
            //    .Select(dm => new TestViewModel { FirstName = dm.FirstName, LastName = dm.LastName, Telephone = dm.Telephone })
            //    .ToList();

            var testDataModel = await _db.TestDataModel.ToListAsync();
            var testViewModel2 = testDataModel.Select(dm => _mapper.Map<TestViewModel>(dm)).ToList();

            var testViewModel3 = await _mapper.ProjectTo<TestViewModel>(_db.TestDataModel).ToListAsync();

            return View(testViewModel3);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}