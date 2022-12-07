using BLL.Domains;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationEmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly EmployeeDomain _employeeDomain;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeeController(EmployeeDomain employeeDomain,
            IWebHostEnvironment webHostEnvironment)
        {
            _employeeDomain = employeeDomain;
            _hostingEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var employees = _employeeDomain.GetAll();
            return View(employees);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        public IActionResult AddEmployee(Employees employees,IFormFile? photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, photo.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    employees.Photo = "/uploads/" + photo.FileName;
                }
                _employeeDomain.Insert(employees);
                return RedirectToAction("Index", "Employee");
            }

            return View("AddEmployee", employees);
        }

        public IActionResult EditEmployee(int id)
        {
            var employee = _employeeDomain.GetById(id);
            return View(employee);
        }

        public IActionResult ModifyEmployee(Employees employees,IFormFile? photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", photo.FileName);
                    using (var newFile = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(newFile);
                    }
                    employees.Photo = "/uploads/" + photo.FileName;
                }

                _employeeDomain.Update(employees);

                return RedirectToAction("Index", "Employee");
            }

            return View("ModifyEmployee", employees);
        }

        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeDomain.GetById(id);
            return View("DeleteEmployee", employee);
        }

        public IActionResult ConfirmDeleteEmployee(int id)
        {
            var employee = _employeeDomain.Delete(id);
            return RedirectToAction("Index", employee);
        }

        public IActionResult ShowEmployeeDay()
        {
            var employees = _employeeDomain.GetAll(); 
            return View(employees);
        }
    }
}
