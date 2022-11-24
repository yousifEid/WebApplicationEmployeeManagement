using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AttendanceRepository
    {
        private EmployeeManagementDbContext _db;

        public AttendanceRepository(EmployeeManagementDbContext db)
        {
            _db = db;
        }

        public Attendance Insert(Attendance attendance)
        {
            _db.Attendances.Add(attendance);
            _db.SaveChanges();
            return attendance;
        }

        public Attendance Update(Attendance attendance)
        {
            _db.Entry(attendance).State = EntityState.Modified;
            _db.SaveChanges();
            return attendance;
        }

        public Attendance Delete(int id)
        {
            var attendance = _db.Attendances.Include(e => e.Employees)
                .Include(e => e.Shift)
                .Where(e => e.Id == id).FirstOrDefault();
            _db.Entry(attendance).State = EntityState.Deleted;
            _db.Attendances.Remove(attendance);
            _db.SaveChanges();
            return attendance;
        }

        public List<Attendance> GetAll()
        {
            var attendance = _db.Attendances.Include(e => e.Employees)
                .Include(e => e.Shift)
                .ToList();

            return attendance;
        }

        public Attendance GetById(int id)
        {
            var attendance = _db.Attendances.Include(e => e.Employees)
                .Include(e => e.Shift)
                .Where(e => e.Id == id).FirstOrDefault();
            return attendance;
        }

        public List<Attendance> GetAttendanceByDate(DateTime date, int? EmployeesId = null)
        {
            var atttendance = _db.Attendances.Include(e => e.Employees).Include(e => e.Shift)
                .Where(e => e.TimeAttendance >= date && e.TimeAttendance < date.AddDays(1)
                            && (EmployeesId.HasValue ? e.EmployeesId == EmployeesId : true))
                .OrderBy(e => e.TimeAttendance)
                .ThenBy(e => e.TimeLeave)
                .ToList();
            return atttendance;
        }
    }
}
