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
        


        [ForeignKey(nameof(Employees))]
        public int EmployeesId { get; set; }
        public Employees? Employees { get; set; }
    }
}
