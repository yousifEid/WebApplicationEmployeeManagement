using BLL.Domains;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationEmployeeManagement.Controllers
{
    public class ShiftController : Controller
    {
        public readonly ShiftDomain _shiftDomain;
        public ShiftController(ShiftDomain shiftDomain)
        {
            _shiftDomain = shiftDomain;
        }
        public IActionResult Index()
        {
            var shifts = _shiftDomain.GetAll();
            return View(shifts);
        }

        public IActionResult CreateShift()
        {
            return View();
        }

        public IActionResult AddShift(Shift shift)
        {
            if (ModelState.IsValid)
            {
                _shiftDomain.Insert(shift);
                return RedirectToAction("Index", "Shift");
            }

            return View("CreateShift", shift);
        }

        public IActionResult EditShift(int id)
        {
            var shift = _shiftDomain.GetById(id);

            return View(shift);
        }

        public IActionResult ModifyShift(Shift shift)
        {
            if (ModelState.IsValid)
            {
                _shiftDomain.Update(shift);

                return RedirectToAction("Index", "Shift");
            }

            return View("Index", shift);
        }

        public IActionResult DeleteShift(int id)
        {
            var shift = _shiftDomain.GetById(id);

            return View("DeleteShift",shift);
        }

        public IActionResult ConfirmDeleteShift(int id)
        {
            var shift = _shiftDomain.Delete(id);

            return RedirectToAction("Index",shift);
        }
    }
}
