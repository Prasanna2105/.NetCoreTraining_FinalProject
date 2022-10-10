﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkForceManagement.API.Models;

namespace WorkForceManagement.API.Abstractions
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDetails>> GetAllEmployees();
    }
}
