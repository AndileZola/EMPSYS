using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using EMPSYS.DAL;
using AutoFixture;
using EMPSYS.DAL.Context;
using AppContext = EMPSYS.DAL.Context.AppContext;
using Bogus;
using Moq.EntityFrameworkCore;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace EMPSYS.TEST
{
    public class EmployeeTest
    {
        private static readonly Fixture Fixture = new Fixture();
        ServiceCollection services = new ServiceCollection();
        [Fact]
        void AddEmployee()
        {          
            var provider = services.BuildServiceProvider();           
            var cs = "Server=.;Database=EMPSYSDB;Integrated Security=True;";          
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            optionsBuilder.UseSqlServer(cs);

            var _ctx = new AppContext(optionsBuilder.Options);
            // Arrange
            Employee employee = GenerateOneEmployee();
            _ctx.Employees.Add(employee);

            // Act
            _ctx.SaveChanges();
            var DbEmployees = _ctx.Employees.ToList();

            // Assert
            Assert.Contains(employee, DbEmployees);
        }
        private List<Employee> GenerateEmployees()
        {
            var emp = new Faker<Employee>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.HireDate, f => f.Date.Recent(0));
            return emp.Generate(5);
            //return emp;
        }
        private Employee GenerateOneEmployee()
        {
            var emp = new Faker<Employee>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.HireDate, f => f.Date.Recent(0));
            return emp;
        }
    }
}
