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
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employees employees, IFormFile? photo)
        {
            if (ModelState.IsValid)
            {
                var employeesByName = _employeeDomain.SearchName(employees.Name);
                if (employeesByName == null)
                {
                    var employeesByEmail = _employeeDomain.SearchMail(employees.Mail);
                    if (employeesByEmail == null)
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
                    else
                    {
                        ModelState.AddModelError("", "لايمكن اضافة ايميل موجود مسبقا");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "الاسم موجود مسبقا");
                }

            }

            return View(employees);
        }

        public IActionResult EditEmployee(int id)
        {
            var employee = _employeeDomain.GetById(id);
            return View(employee);
        }

        public IActionResult ModifyEmployee(Employees employees, IFormFile? photo)
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

        public IActionResult ShowEmployeeDay(DateTime date)
        {
            var employees = _employeeDomain.GetAll();
            ViewBag.date = date;

            return View(employees);
        }
    }
}
