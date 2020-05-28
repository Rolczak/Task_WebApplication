using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZadanieRekrutacja.ViewModels
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public string HireDate { get; set; }
        public string PerformanceManagerName { get; set; }
    }
}
