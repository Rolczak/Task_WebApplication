using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZadanieRekrutacja.DataAccess.Data;
using ZadanieRekrutacja.Models;
using ZadanieRekrutacja.ViewModels;

namespace ZadanieRekrutacja.Services
{
    public class EmployeeFiltering : IEmployeeFiltering
    {
        private readonly IServiceProvider _provider;
        private readonly IMapper _mapper;
        public EmployeeFiltering(IServiceProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeViewModel> GetFilteredEmployees(string NameExpression, DateTime? beginDate, DateTime? endDate, Employee manager)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();

                if (!beginDate.HasValue)
                    beginDate = DateTime.MinValue;

                if (!endDate.HasValue)
                    endDate = DateTime.MaxValue;

                //Filter by hiring dates
                var filteredEmployees = db.Employees.Include(e => e.PerformanceManager).Where(e => e.HireDate > beginDate).Where(e => e.HireDate < endDate);
                //Filter by Name
                if (NameExpression != null)
                {
                    filteredEmployees = filteredEmployees.Where(e => e.Name.ToLower().StartsWith(NameExpression.ToLower()));
                }
                //Filter by manager
                if (manager != null)
                {
                    filteredEmployees = filteredEmployees.Where(e => e.PerformanceManager == manager);
                }

                return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(filteredEmployees);
            }
        }
        public string[] GetEmployeeNames(string term)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();

                return db.Employees.AsEnumerable()
                    .Where(e => e.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    .Select(e => e.Name)
                    .Take(5)
                    .ToArray();
            }
        }

        public Employee GetPerformanceManager(int id)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();

                return db.Employees.Find(id);
            }
        }

        public List<SelectListItem> GetManagersSelectList()
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();

                List<SelectListItem> managerList = new List<SelectListItem>();
                var managers = db.Employees;

                managerList.Add(new SelectListItem(){
                    Text = "None",
                    Value = null
                });

                foreach(var manager in managers)
                {
                    managerList.Add(new SelectListItem()
                    {
                        Text = manager.Name,
                        Value = manager.Id.ToString()
                    });
                }
                return managerList;
            }
        }
    }
}
