using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkForceManagement.API.Abstractions;
using WorkForceManagement.API.Models;

namespace WorkForceManagement.API.Services
{
    public class SoftlockService : ISoftlockService
    {
        private readonly WFMDbContext _wfmDbContext;
        public SoftlockService(WFMDbContext wFMDbContext)
        {
            _wfmDbContext = wFMDbContext;
        }
        public async Task<IEnumerable<SoftlockDetails>> GetAllSoftlocks()
        {
            var result = await _wfmDbContext.Softlocks.Include(s => s.employees).Where(s => s.managerstatus == "awaiting_confirmation")
                        .Select(s => new SoftlockDetails
                        {
                            lockid = s.lockid,
                            employee_id = s.employee_id,
                            employee_name = s.employees.employee_name,
                            manager = s.manager,
                            managerstatus = s.managerstatus,
                            requestmessage = s.requestmessage,
                            reqdate = s.reqdate,
                        }).ToListAsync();

            return result;
        }
        public SoftlockDetails GetSoftlocksById(int lockid)
        {
            SoftlockDetails softlockDetails = new SoftlockDetails();
            var result = _wfmDbContext.Softlocks.Include(s => s.employees).FirstOrDefault(s => s.lockid == lockid);
            if (result != null)
            {
                softlockDetails.lockid = result.lockid;
                softlockDetails.employee_id = result.employee_id;
                softlockDetails.employee_name = result.employees.employee_name;
                softlockDetails.manager = result.manager;
                softlockDetails.managerstatus = result.managerstatus;
                softlockDetails.requestmessage = result.requestmessage;
                softlockDetails.reqdate = result.reqdate;
               
                return softlockDetails;
            }
            else
            {
                return softlockDetails;
            }
        }
        public string InsertSoftlock(SoftlockDetails softlockDetails)
        {
            if (softlockDetails != null)
            {
                _wfmDbContext.Add(new Softlocks
                {
                    employee_id = softlockDetails.employee_id,
                    manager = softlockDetails.manager,
                    managerstatus = "awaiting_confirmation",
                    reqdate = DateTime.UtcNow,
                    requestmessage = softlockDetails.requestmessage,
                    lastupdated = DateTime.UtcNow,
                    mgrlastupdate = DateTime.UtcNow
                });
                //To update lockstatus in employee table
                var employee = _wfmDbContext.Employees.Include(s => s.softlocks).FirstOrDefault(s => s.employee_id == softlockDetails.employee_id);
                employee.lockstatus = "request_waiting";
                _wfmDbContext.Update(employee);
                _wfmDbContext.SaveChanges();
                return "SoftLock Inserted Successfully";
            }
            else
            {
                return "Data not found";
            }
        }

        public string UpdateSoftlockStatus(SoftlockDetails softlockDetails)
        {
            var softLock = _wfmDbContext.Softlocks.Include(s => s.employees).FirstOrDefault(s => s.lockid == softlockDetails.lockid);
            if (softLock != null)
            {
                //To update lockstatus in both softlock and employee table
                if (softlockDetails.managerstatus == "Accepted")
                {
                    softLock.managerstatus = softlockDetails.managerstatus;
                    softLock.employees.lockstatus = "locked";
                    softLock.lastupdated = DateTime.UtcNow;

                }
                else
                {
                    softLock.managerstatus = softlockDetails.managerstatus;
                    softLock.employees.lockstatus = "not_requested";
                    softLock.lastupdated = DateTime.UtcNow;
                }
                _wfmDbContext.Update(softLock);
                _wfmDbContext.SaveChanges();

                return "Softlock Updated Successfully";

            }
            else
            {
                return "Data not found";
            }
        }
    }
}
