using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EmployeeCRUD.Services;
namespace EmployeeCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _service;

        public HomeController(IEmployeeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var employees = _service.GetAll();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _service.Add(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _service.GetById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _service.Update(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
