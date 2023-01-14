using BLL.Domains;
using BLL.Dtos;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceDomain _attendanceDomain;

        public AttendanceController(AttendanceDomain attendanceDomain)
        {
            _attendanceDomain = attendanceDomain;
        }

        [HttpPost("[action]")]
        public BLL.Dtos.ResponseObject<Attendance> Insert(Attendance attendance)
        {
            return _attendanceDomain.Insert(attendance);
        }

        [HttpPost("[action]")]
        public BLL.Dtos.ResponseObject<Attendance> Update(Attendance attendance)
        {
            return _attendanceDomain.Update(attendance);
        }

        [HttpDelete("[action]/{id}")]
        public Attendance Delete(int id)
        {
            return _attendanceDomain.Delete(id);
        }

        [HttpGet("[action]")]
        public List<Attendance> GetAll()
        {
            return _attendanceDomain.GetAll();
        }

        [HttpGet("[action]/{date}/{EmployeesId?}/{shiftId?}")]
        public List<Attendance> GetAttendanceByDate(DateTime date, int? EmployeesId = null,
            int? shiftId = null)
        {
            return _attendanceDomain.GetAttendanceByDate(date, EmployeesId, shiftId);
        }

        [HttpGet("[action]/{date}/{EmployeesId}/{shiftId}")]
        public List<Attendance> SearchAttendance(DateTime date, int? EmployeesId = null,
            int? shiftId = null) 
        {
            return _attendanceDomain.SearchAttendance(date, EmployeesId, shiftId);
        }
    }
}
