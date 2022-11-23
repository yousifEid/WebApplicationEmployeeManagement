using BLL.Domains;
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
            EmployeeDomain employeeDomain,ShiftDomain shiftDomain)
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

        public IActionResult CreateAttendance()
        {
            List<Employees> employees = _employeeDomain.GetAll();
            ViewBag.Employees = new SelectList(employees, "Id", "Name");

            List<Shift> shifts = _shiftDomain.GetAll();
            ViewBag.Shift = new SelectList(shifts, "Id", "ShiftName");

            return View();
        }

        public IActionResult AddAttendance(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _attendanceDomain.Insert(attendance);
                return RedirectToAction("Index", "Attendance");
            }

            List<Employees> employees = _employeeDomain.GetAll();
            ViewBag.Employees = new SelectList(employees, "Id", "Name");

            List<Shift> shifts = _shiftDomain.GetAll();
            ViewBag.Shift = new SelectList(shifts, "Id", "ShiftName");


            return View("CreateAttendance", attendance);
        }

        public IActionResult EditAttendance(int id)
        {
            var attendance = _attendanceDomain.GetById(id);

            List<Employees> employees = _employeeDomain.GetAll();
            ViewBag.Employees = new SelectList(employees, "Id", "Name");

            List<Shift> shifts = _shiftDomain.GetAll();
            ViewBag.Shift = new SelectList(shifts, "Id", "ShiftName");

            return View(attendance);
        }

        public IActionResult ModifyAttendance(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _attendanceDomain.Update(attendance);

                return RedirectToAction("Index", "Attendance");
            }

            return View("Index", attendance);
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

        public IActionResult ShowAttendance(DateTime date)
        {
            var attendance = _attendanceDomain.GetAttendanceByDate(date);
            ViewBag.date = date;
            return View(attendance);
        }
    }
}
