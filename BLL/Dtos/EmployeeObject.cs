﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class EmployeeObject
    {
        public Employees Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
