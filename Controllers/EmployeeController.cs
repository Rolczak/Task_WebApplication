using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZadanieRekrutacja.Models;
using ZadanieRekrutacja.Services;

namespace ZadanieRekrutacja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeFiltering _employeeFiltering;

        public EmployeeController(IEmployeeFiltering employeeFiltering)
        {
            _employeeFiltering = employeeFiltering;
        }

        //api/employee/get?...
        [HttpGet("get")]
        public IActionResult GetFiltered([FromQuery]string nameTerm = null,[FromQuery] DateTime? beginDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] int? performanceManagerId = null)
        {
            Employee manager = null;
            if (performanceManagerId.HasValue)
            {
                manager = _employeeFiltering.GetPerformanceManager(performanceManagerId.Value);
            }

          return Ok(new { data = _employeeFiltering.GetFilteredEmployees(nameTerm, beginDate, endDate, manager) });
        }

        //api/employee/autocomplete/get
        [HttpGet("autocomplete/get")]
        public IActionResult GetAutocompleteNames([FromQuery]string term)
        {
            return Ok(_employeeFiltering.GetEmployeeNames(term));
        }

        //api/employee/managers/get
        [HttpGet("managers/get")]
        public IActionResult GetManagerList()
        {
            return Ok(_employeeFiltering.GetManagersSelectList());
        }
    }
}
