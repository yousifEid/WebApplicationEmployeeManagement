using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class EmployeeDomain
    {
        public readonly EmployeeRepository _employeeRepository;

        public EmployeeDomain(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employees Insert(Employees employees)
        {
            return _employeeRepository.Insert(employees);
        }

        public Employees Update(Employees employees)
        {
            return _employeeRepository.Update(employees);
        }

        public Employees Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        public List<Employees> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employees GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public Employees SearchMail(string mail)
        {
            return _employeeRepository.SearchMail(mail);
        }
    }
}
