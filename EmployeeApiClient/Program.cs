using System;
using System.Net.Http;

namespace EmployeeApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMDB API client");

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://www.omdbapi.com/");

            // search for Batman movies
            Console.Write("Search movie by title: ");
            string title = Console.ReadLine();
            var res = client.GetAsync(String.Format("?apikey=fa5c6c0a&s={0}", title)).Result;

            if(res.IsSuccessStatusCode)
            {
                SearchMoviesResult movies = res.Content.ReadAsAsync<SearchMoviesResult>().Result;

                Console.WriteLine("Movies in the IMDB: ");
                foreach(var m in movies.Search)
                {
                    Console.WriteLine("Title: {0}, year {1}", m.Title, m.Year);
                }
            }
        }

        static void Main2(string[] args)
        {
            Console.WriteLine("Employee API client");

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1/");

            // 1. Display all employees
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

            // 2. Get some employee
            Console.WriteLine("Enter employee id: ");
            int id = int.Parse(Console.ReadLine());

            var res2 = client.GetAsync("employee/" + id).Result; // employee/5 or employee/1
            if(res2.IsSuccessStatusCode)
            {
                // result for single employee data
                SingleEmployee employee = res2.Content.ReadAsAsync<SingleEmployee>().Result;

                Console.WriteLine("Information:");
                Console.WriteLine("Name: {0}", employee.data.employee_name);
                Console.WriteLine("Age: {0}", employee.data.employee_age);
                Console.WriteLine("Salary: EUR {0}", employee.data.employee_salary);
            }

            Console.Read();
        }
    }
}
