using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtsWebApi.Interfaces;
using UtsWebApi.Models.RequestResponse;

namespace UtsWebApi.Controllers
{
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        private IStaffService _staffService = null;

        public StaffController(IStaffService staffService)
        {
            this._staffService = staffService;

        }

        [HttpGet("Search")]
        public IActionResult Search([FromQuery]StaffServiceFindRequest findRequest)
        {            
            var response = _staffService.Find(findRequest);
            return Ok(response);
        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery]int id)
        {
            var response = _staffService.Get(id);
            return Ok(response);
        }

        [HttpPut("LikeReceived")]
        public async Task<IActionResult> LikeReceived([FromQuery]int employeeId)
        {
            await _staffService.LikeReceived(employeeId);
            return Ok();
        }
    }
}