using BLL.Domains;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ShiftController : ControllerBase
    {
        private readonly ShiftDomain _shiftDomain;

        public ShiftController(ShiftDomain shiftDomain)
        {
            _shiftDomain = shiftDomain;
        }

        [HttpPost("[action]")]
        public Shift Insert(Shift shift)
        {
            return _shiftDomain.Insert(shift);
        }

        [HttpPost("[action]")]
        public Shift Update(Shift shift)
        {
            return _shiftDomain.Update(shift);
        }

        [HttpDelete("[action]/{id}")]
        public Shift Delete(int id)
        {
            return _shiftDomain.Delete(id);
        }

        [HttpGet("[action]")]
        public List<Shift> GetAll()
        {
            return _shiftDomain.GetAll();
        }
    }
}
