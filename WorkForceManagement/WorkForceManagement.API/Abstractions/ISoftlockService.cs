using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkForceManagement.API.Models;

namespace WorkForceManagement.API.Abstractions
{
    public interface ISoftlockService
    {
        Task<IEnumerable<SoftlockDetails>> GetAllSoftlocks();
        string InsertSoftlock(SoftlockDetails softlockDetails);
        string UpdateSoftlockStatus(SoftlockDetails softlockDetails);
        SoftlockDetails GetSoftlocksById(int lockid);
    }
}
