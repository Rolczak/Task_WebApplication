using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZadanieRekrutacja.Models;
using ZadanieRekrutacja.ViewModels;

namespace ZadanieRekrutacja.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.PerformanceManagerName,
                opt => opt.MapFrom(src => src.PerformanceManager.Name))
                .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate.ToString("dd-MM-yyyy")));
        }
    }
}
