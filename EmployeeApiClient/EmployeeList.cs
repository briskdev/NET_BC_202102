using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApiClient
{
    public class EmployeeList
    {
        public string status { get; set; }

        public List<Employee> data { get; set; }
    }
}