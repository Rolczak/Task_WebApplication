using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZadanieRekrutacja.Models;
using ZadanieRekrutacja.Services;

namespace ZadanieRekrutacja.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeFiltering _employeeFiltering;

        public HomeController(ILogger<HomeController> logger, IEmployeeFiltering employeeFiltering)
        {
            _logger = logger;
            _employeeFiltering = employeeFiltering;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region API_CALLS

        [Route("employee/{nameTerm?}/{beginDate?}/{endDate?}/{performanceManagerId?}")]
        public IActionResult GetFiltered(string nameTerm = null, DateTime? beginDate = null, DateTime? endDate = null, int? performanceManagerId = null)
        {
            Employee manager = null;
            if (performanceManagerId.HasValue)
            {
                manager = _employeeFiltering.GetPerformanceManager(performanceManagerId.Value);
            }

            return Json(new { data = _employeeFiltering.GetFilteredEmployees(nameTerm, beginDate, endDate, manager) });
        }
        public IActionResult GetAutocompleteNames(string term)
        {
            return Json(_employeeFiltering.GetEmployeeNames(term));
        }

        public IActionResult GetManagerList()
        {
            return Json(_employeeFiltering.GetManagersSelectList());
        }
        #endregion
    }
}
