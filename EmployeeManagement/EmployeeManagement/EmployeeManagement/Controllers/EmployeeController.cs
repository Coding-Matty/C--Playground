using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        //setting up the dependency injection
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var employees = _dbContext.Employees.ToList();
            
            ViewBag.Employees = employees;
            
            
            return View();
        }

        public IActionResult CreateEdit(int id) 
        {
            return View("CreateEditEmployee");
        }

        [HttpPost]
        public IActionResult CreateEditEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
