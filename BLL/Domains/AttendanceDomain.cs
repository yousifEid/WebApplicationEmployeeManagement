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
    public class AttendanceDomain
    {
        public readonly AttendanceRepository _attendanceRepository;

        public AttendanceDomain(AttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public ResponseObject Insert(Attendance attendance)
        {
            ResponseObject result = new ResponseObject();

            if (attendance.TimeLeave <= DateTime.Now)
            {
                if (attendance.TimeAttendance <= DateTime.Now)
                {
                    if (attendance.TimeAttendance.ToString("yyyy-MM-dd") == attendance.TimeLeave.ToString("yyyy-MM-dd")
                        || attendance.ShiftId == 3)
                    {
                        result.Data = _attendanceRepository.Insert(attendance);
                    }
                    else
                    {
                        result.ErrorMessage = "تاريخ الايام غير مطابق";
                    }
                }
                else
                {
                    result.ErrorMessage = "تاريخ الحضور اكبر من التاريخ الحالي";
                }
            }
            else
            {
                result.ErrorMessage = "تاريخ الانصراف اكبر من التاريخ الحالي";
            }

            return result;
        }

        public ResponseObject Update(Attendance attendance)
        {
            ResponseObject result = new ResponseObject();

            if (attendance.TimeLeave <= DateTime.Now)
            {
                if (attendance.TimeAttendance <= DateTime.Now)
                {
                    if (attendance.TimeAttendance.ToString("yyyy-MM-dd") == attendance.TimeLeave.ToString("yyyy-MM-dd")
                        || attendance.ShiftId == 3)
                    {
                        result.Data = _attendanceRepository.Update(attendance);
                    }
                    else
                    {
                        result.ErrorMessage = "تاريخ الايام غير مطابق";
                    }
                }
                else
                {
                    result.ErrorMessage = "تاريخ الحضور اكبر من التاريخ الحالي";
                }
            }
            else
            {
                result.ErrorMessage = "تاريخ الانصراف اكبر من التاريخ الحالي";
            }

            return result;
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

        public List<Attendance> GetAttendanceByDate(DateTime date, int? EmployeesId = null,
            int? shiftId = null)
        {
            return _attendanceRepository.GetAttendanceByDate(date, EmployeesId,shiftId);
        }

        public List<Attendance> SearchAttendance(DateTime date,int? employeesId = null,
            int? shiftId =null)
        {
            return _attendanceRepository.SearchAttendance(date,employeesId,shiftId);
        }
    }
}
