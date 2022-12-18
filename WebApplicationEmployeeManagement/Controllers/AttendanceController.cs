using BLL.Domains;
using BLL.Dtos;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationEmployeeManagement.Controllers
{
    public class AttendanceController : Controller
    {
        public readonly AttendanceDomain _attendanceDomain;
        public readonly EmployeeDomain _employeeDomain;
        public readonly ShiftDomain _shiftDomain;

        public AttendanceController(AttendanceDomain attendanceDomain,
            EmployeeDomain employeeDomain, ShiftDomain shiftDomain)
        {
            _attendanceDomain = attendanceDomain;
            _employeeDomain = employeeDomain;
            _shiftDomain = shiftDomain;
        }

        public IActionResult Index()
        {
            var attendance = _attendanceDomain.GetAll();
            return View(attendance);
        }
        [HttpGet]
        public IActionResult CreateAttendance()
        {
            List<Employees> employees = _employeeDomain.GetAll();
            ViewData["Employees"] = new SelectList(employees, "Id", "Name");

            List<Shift> shifts = _shiftDomain.GetAll();
            ViewData["Shifts"] = new SelectList(shifts, "Id", "ShiftName");

            return View();
        }
        [HttpPost]
        public IActionResult CreateAttendance(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                var result = _attendanceDomain.Insert(attendance);
                if (result.Data != null)
                {
                    return RedirectToAction("Index", "Attendance");
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage);
                }
            }

            List<Employees> employees = _employeeDomain.GetAll();
            ViewData["Employees"] = new SelectList(employees, "Id", "Name");

            List<Shift> shifts = _shiftDomain.GetAll();
            ViewData["Shifts"] = new SelectList(shifts, "Id", "ShiftName");

            return View(attendance);
        }
        [HttpGet]
        public IActionResult EditAttendance(int id)
        {
            var attendance = _attendanceDomain.GetById(id);

            List<Employees> employees = _employeeDomain.GetAll();
            ViewData["Employees"] = new SelectList(employees, "Id", "Name");

            List<Shift> shifts = _shiftDomain.GetAll();
            ViewData["Shifts"] = new SelectList(shifts, "Id", "ShiftName");

            return View(attendance);
        }
        [HttpPost]
        public IActionResult EditAttendance(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
               var result = _attendanceDomain.Update(attendance);
                if (result.Data != null)
                {
                    return RedirectToAction("Index", "Attendance");
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage);
                }
            }

            List<Employees> employees = _employeeDomain.GetAll();
            ViewData["Employees"] = new SelectList(employees, "Id", "Name");

            List<Shift> shifts = _shiftDomain.GetAll();
            ViewData["Shifts"] = new SelectList(shifts, "Id", "ShiftName");


            return View(attendance);
        }

        public IActionResult DeleteAttendance(int id)
        {
            var attendance = _attendanceDomain.GetById(id);

            return View("DeleteAttendance", attendance);
        }

        public IActionResult ConfirmDeleteAttendance(int id)
        {
            var attendance = _attendanceDomain.Delete(id);

            return RedirectToAction("Index", attendance);
        }

        public IActionResult ShowAttendance(DateTime date, int? EmployeesId = null,
           int? shiftId = null)
        {
            var attendance = _attendanceDomain.GetAttendanceByDate(date, EmployeesId, shiftId);
            ViewBag.date = date;

            List<Employees> employees = _employeeDomain.GetAll();
            ViewBag.Employees = new SelectList(employees, "Id", "Name");

            List<Shift> shifts = _shiftDomain.GetAll();
            ViewBag.Shift = new SelectList(shifts, "Id", "ShiftName");

            return View(attendance);
        }

        public IActionResult AttendanceDate(DateTime date, int? employeesId = null,
           int? shiftId = null)
        {
            var attendance = _attendanceDomain.SearchAttendance(date, employeesId, shiftId);
            ViewBag.date = date;

            List<Employees> employees = _employeeDomain.GetAll();
            ViewBag.Employees = new SelectList(employees, "Id", "Name");



            List<Shift> shifts = _shiftDomain.GetAll();
            ViewBag.Shift = new SelectList(shifts, "Id", "ShiftName");

            return View(attendance);
        }


    }
}
