using BLL.Domains;
using BLL.Dtos;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDomain _employeeDomain;

        public EmployeesController(EmployeeDomain employeeDomain)
        {
            _employeeDomain = employeeDomain;
        }

        [HttpPost("[action]")]
        public ResponseObject<Employees> Insert(Employees employees)
        {
            return _employeeDomain.Insert(employees);
        }
        [HttpPost("[action]")]
        public Employees Update(Employees employees)
        {
            return _employeeDomain.Update(employees);
        }

        [HttpDelete("[action]/{id}")]
        public Employees Delete(int id)
        {
            return _employeeDomain.Delete(id);
        }

        [HttpGet("[action]")]
        public List<Employees> GetAll()
        {
            return _employeeDomain.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public Employees GetById(int id)
        {
            return _employeeDomain.GetById(id);
        }

        [HttpGet("[action]/{mail}")]
        public Employees SearchMail(string mail)
        {
            return _employeeDomain.SearchMail(mail);
        }

        [HttpGet("[action]/{name}")]
        public Employees SearchName(string name)
        {
            return _employeeDomain.SearchName(name);
        }
    }
}