using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZadanieRekrutacja.Models;

namespace ZadanieRekrutacja.DataAccess.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().HasOne(e => e.PerformanceManager)
                .WithMany()
                .HasForeignKey(pm => pm.PerformanceManagerId);
            builder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Anna", HireDate = new DateTime(2015, 7, 13) },
                new Employee { Id = 2, Name = "Jan", HireDate = new DateTime(2012, 2, 25), PerformanceManagerId = 1 },
                new Employee { Id = 3, Name = "Andrzej", HireDate = new DateTime(2018, 3, 27), PerformanceManagerId = 1 },
                new Employee { Id = 4, Name = "Piotr", HireDate = new DateTime(2010, 10, 10), PerformanceManagerId = 2 },
                new Employee { Id = 5, Name = "Katarzyna", HireDate = new DateTime(2011, 2, 1), PerformanceManagerId = 2 },
                new Employee { Id = 6, Name = "Barbara", HireDate = new DateTime(2019, 1, 5), PerformanceManagerId = 2 },
                new Employee { Id = 7, Name = "Ewa", HireDate = new DateTime(2015, 5, 17), PerformanceManagerId = 4 },
                new Employee { Id = 8, Name = "Zofia", HireDate = new DateTime(2009, 2, 5), PerformanceManagerId = 2 },
                new Employee { Id = 9, Name = "Marian", HireDate = new DateTime(2018, 9, 9), PerformanceManagerId = 5 },
                new Employee { Id = 10, Name = "Michał", HireDate = new DateTime(2011, 11, 11), PerformanceManagerId = 3 },
                new Employee { Id = 11, Name = "Mateusz", HireDate = new DateTime(2013, 5, 13) },
                new Employee { Id = 12, Name = "Wiesław", HireDate = new DateTime(2017, 7, 4) },
                new Employee { Id = 13, Name = "Edyta", HireDate = new DateTime(2013, 12, 13), PerformanceManagerId = 10 },
                new Employee { Id = 14, Name = "Patrycja", HireDate = new DateTime(2018, 2, 13), PerformanceManagerId = 10 },
                new Employee { Id = 15, Name = "Tomasz", HireDate = new DateTime(2019, 5, 15), PerformanceManagerId = 10 }
                );
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
