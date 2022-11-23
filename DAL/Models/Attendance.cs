using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime TimeAttendance { get; set; }
        public DateTime TimeLeave { get; set; }

        [NotMapped]
        public TimeSpan Duration
        {
            get
            {
                if (TimeLeave != null && TimeAttendance != null)
                    return TimeLeave - TimeAttendance;

                return default;
            }
        }


        [ForeignKey(nameof(Employees))]
        public int EmployeesId { get; set; }
        public Employees? Employees { get; set; }


        [ForeignKey(nameof(Shift))]
        public int ShiftId { get; set; } 
        public Shift? Shift { get; set; }
    }
}
