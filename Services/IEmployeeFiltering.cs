using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZadanieRekrutacja.Models;
using ZadanieRekrutacja.ViewModels;

namespace ZadanieRekrutacja.Services
{
    public interface IEmployeeFiltering
    {
        public IEnumerable<EmployeeViewModel> GetFilteredEmployees(string NameExpression, DateTime? beginDate, DateTime? endDate, Employee manager);

        public string[] GetEmployeeNames(string term);

        public Employee GetPerformanceManager(int id);

        public List<SelectListItem> GetManagersSelectList();
    }
}
