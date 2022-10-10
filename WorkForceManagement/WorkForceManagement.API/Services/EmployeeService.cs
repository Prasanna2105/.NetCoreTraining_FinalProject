using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkForceManagement.API.Abstractions;
using WorkForceManagement.API.Models;

namespace WorkForceManagement.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly WFMDbContext _wfmDbContext;
        public EmployeeService(WFMDbContext wFMDbContext)
        {
            _wfmDbContext = wFMDbContext;
        }
        public async Task<IEnumerable<EmployeeDetails>> GetAllEmployees()
        {
            var result = await _wfmDbContext.Employees.Include(x => x.skillmaps).ThenInclude(x => x.skills).Where(x=>x.lockstatus == "not_requested")
                        .Select(x => new EmployeeDetails
                        {
                            employee_id = x.employee_id,
                            employee_name = x.employee_name,
                            status = x.status,
                            manager = x.manager,
                            wfm_manager = x.wfm_manager,
                            email = x.email,
                            experience = x.experience,
                            lockstatus = x.lockstatus,
                            skills = x.skillmaps.Select(y => y.skills.skillname).ToList()
                        }).ToListAsync();

            return result;
        }
    }
}
