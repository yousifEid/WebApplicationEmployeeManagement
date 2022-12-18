using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class ResponseObject
    {
        public Attendance Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
