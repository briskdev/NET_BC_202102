using System;
using System.Net.Http;

namespace EmployeeApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee API client");

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1/");

            // 1. Display all emplyees
            Console.WriteLine("Employees:");

            // using method 'employees'
            var res = client.GetAsync("employees").Result;

            // checking that there were no technical problems and successfully received answer
            if(res.IsSuccessStatusCode)
            {
                // parse JSON content to C# class
                EmployeeList data = res.Content.ReadAsAsync<EmployeeList>().Result;

                // display employee
                foreach(Employee emp in data.data)
                {
                    Console.WriteLine("{0}: EUR {1}", emp.employee_name, emp.employee_salary);
                }
            }

            // 2. 

            Console.Read();
        }
    }
}
