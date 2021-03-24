using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")] // http://localhost/employees
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "John",
                Surname ="Smith",
                Department = "IT"
            },
            new Employee()
            {
                Id = 2,
                Name = "Ann",
                Surname = "Addams",
                Department = "Marketing"
            }
        };

        // http://localhost/employees
        [HttpGet]
        public List<Employee> Get()
        {
            return employees.OrderBy(e => e.Surname).ToList();
        }

        // http://localhost/employees/{id}
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
