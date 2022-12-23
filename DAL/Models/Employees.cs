using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employees
    {
        public Employees()
        {
            Attendances = new List<Attendance>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string? Photo { get; set; }
        public int IdNumber { get; set; }
        public string Gender { get; set; }
        public string Mail { get; set; }
        public int Tel { get; set; }
        public int IdJob { get; set; }


        public List<Attendance>? Attendances { get; set; }
    }
}
