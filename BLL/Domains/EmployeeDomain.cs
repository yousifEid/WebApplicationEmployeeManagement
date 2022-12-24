using BLL.Dtos;
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

        public EmployeeObject Insert(Employees employees)
        {
            EmployeeObject employeeObject = new EmployeeObject();

            var employeesByName = _employeeRepository.SearchName(employees.Name);
            if (employeesByName == null)
            {
                var employeesByEmail = _employeeRepository.SearchMail(employees.Mail);
                if (employeesByEmail == null)
                {
                    employeeObject.Data = _employeeRepository.Insert(employees);
                }
                else
                {
                    employeeObject.ErrorMessage = "لايمكن اضافة ايميل موجود مسبقا";
                }

            }
            else
            {
                employeeObject.ErrorMessage = "الاسم موجود مسبقا";
            }

            return employeeObject;
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

        public Employees SearchName(string name)
        {
            return _employeeRepository.SearchName(name);
        }
    }
}
