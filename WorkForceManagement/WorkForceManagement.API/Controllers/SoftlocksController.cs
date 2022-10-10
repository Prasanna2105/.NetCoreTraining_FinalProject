using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkForceManagement.API.Abstractions;
using WorkForceManagement.API.Helpers;
using WorkForceManagement.API.Models;

namespace WorkForceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SoftlocksController : ControllerBase
    {
        private readonly ISoftlockService _softlockService;
        public SoftlocksController(ISoftlockService softlockService)
        {
            _softlockService = softlockService;
        }

        [HttpGet]
        [Route("GetSoftLocks")]
        public async Task<ActionResult> GetSoftLocks()
        {
            try
            {
                var softlockList = await _softlockService.GetAllSoftlocks();
                return Ok(softlockList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetSoftLocksById")]
        public ActionResult GetSoftLocksById(int lockid)
        {
            try
            {
                var softlock =  _softlockService.GetSoftlocksById(lockid);
                return Ok(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("InsertSoftLock")]
        public ActionResult InsertSoftLock(SoftlockDetails softlockDetails)
        {
            try
            {
                var softlock = _softlockService.InsertSoftlock(softlockDetails);
                return Ok(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("UpdateSoftlockStatus")]
        public ActionResult UpdateSoftLockStatus(SoftlockDetails softlockDetails)
        {
            try
            {
                var softlock = _softlockService.UpdateSoftlockStatus(softlockDetails);
                return Ok(softlock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
