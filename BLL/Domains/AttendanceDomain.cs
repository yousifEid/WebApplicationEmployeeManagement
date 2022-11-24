using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class AttendanceDomain
    {
        public readonly AttendanceRepository _attendanceRepository;

        public AttendanceDomain(AttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public Attendance Insert(Attendance attendance)
        {
            return _attendanceRepository.Insert(attendance);
        }

        public Attendance Update(Attendance attendance)
        {
            return _attendanceRepository.Update(attendance);
        }

        public Attendance Delete(int id)
        {
            return _attendanceRepository.Delete(id);
        }

        public List<Attendance> GetAll()
        {
            return _attendanceRepository.GetAll();
        }

        public Attendance GetById(int id)
        {
            return _attendanceRepository.GetById(id);
        }

        public List<Attendance> GetAttendanceByDate(DateTime date, int? EmployeesId = null)
        {
            return _attendanceRepository.GetAttendanceByDate(date, EmployeesId);
        }
    }
}
