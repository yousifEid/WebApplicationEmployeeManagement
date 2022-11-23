using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ShiftRepository
    {
        private EmployeeManagementDbContext _db;
        public ShiftRepository(EmployeeManagementDbContext db)
        {
            _db = db;
        }

        public Shift Insert(Shift shift)
        {
            _db.Shifts.Add(shift);
            _db.SaveChanges();
            return shift;
        }

        public Shift Update(Shift shift)
        {
            _db.Entry(shift).State = EntityState.Modified;
            _db.SaveChanges();
            return shift;
        }

        public Shift Delete(int id)
        {
            var shift = _db.Shifts.Where(e => e.Id == id).FirstOrDefault();
            _db.Entry(shift).State = EntityState.Deleted;
            _db.Shifts.Remove(shift);
            _db.SaveChanges();
            return shift;
        }

        public List<Shift> GetAll()
        {
            var shifts = _db.Shifts.ToList();

            return shifts;
        }

        public Shift GetById(int id)
        {
            var shift = _db.Shifts.Where(e => e.Id == id).FirstOrDefault();

            return shift;
        }
    }
}
