using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository
    {
        private EmployeeManagementDbContext _db;

        public EmployeeRepository(EmployeeManagementDbContext db)
        {
            _db = db;
        }

        public Employees Insert(Employees employees)
        {
            _db.Employees.Add(employees);
            _db.SaveChanges();
            return employees;
        }

        public Employees Update(Employees employees)
        {
            _db.Entry(employees).State = EntityState.Modified;
            _db.SaveChanges();
            return employees;
        }

        public Employees Delete(int id)
        {
            var employees = _db.Employees.Where(e => e.Id == id).FirstOrDefault();
            _db.Entry(employees).State = EntityState.Deleted;
            _db.Employees.Remove(employees);
            _db.SaveChanges();
            return employees;
        }

        public List<Employees> GetAll()
        {
            var employee = _db.Employees.Include(e => e.Attendances).ToList();

            return employee;
        }

        public Employees GetById(int id)
        {
            var employee = _db.Employees.Where(e => e.Id == id).FirstOrDefault();
            return employee;
        }

        public Employees SearchMail(string mail)
        {
            var employee = _db.Employees.Include(e=>e.Attendances).Where(e => e.Mail == mail).FirstOrDefault();
            return employee;
        }

        public Employees SearchName(string name)
        {
            var employee = _db.Employees.Include(e => e.Attendances).Where(e => e.Name == name).FirstOrDefault();
            return employee;
        }
    }
}
