using SampleDb.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SampleDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sample database usage");

            Console.WriteLine("1st approach - SqlDataClient");

            // I - SqlDataClient
            string dbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Briska\source\repos\NET_BC_202102\NET_BC\MyFirstDb.mdf;Integrated Security=True;Connect Timeout=30";

            using(SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();

                string query = "select * from Users ORDER BY RegisteredOn ASC";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        // read row by row
                        while(reader.Read())
                        {
                            string firstName = Convert.ToString(reader["FirstName"]);
                            string lastName = Convert.ToString(reader["LastName"]);
                            DateTime registeredOn = Convert.ToDateTime(reader["RegisteredOn"]);

                            Console.WriteLine("User {0} {1}, created on {2}", firstName, lastName, registeredOn);
                        }
                    }
                }

                connection.Close();
            }

            Console.WriteLine("2nd approach - Entity Framework");

            // II - Entity Framework
            // 1. Add reference to Nuget Package "Microsoft.EntityFrameworkCore.Tools" 3.1.X version
            // 2. Add reference to Nuget Package "Microsoft.EntityFrameworkCore.SqlServer" 3.1.X version
            // 3. Use Package Manager Console (select correct active project) and scaffold database:
            //    Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\XX\MyFirstDb.mdf;Integrated Security=True;Connect Timeout=30" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DB -Context SampleDatabase
            // 4. Use generated classes

            // To add data:
            using (SampleDatabase db = new SampleDatabase())
            {
                db.Users.Add(new Users()
                {
                    FirstName = "New",
                    LastName = "User",
                    RegisteredOn = DateTime.Now,
                });

                db.SaveChanges();
            }

            // To modify data:
            using (SampleDatabase db = new SampleDatabase())
            {
                var user = db.Users.FirstOrDefault(u => u.LastName == "User");
                if(user != null)
                {
                    user.LastName = "updated user";
                }

                db.SaveChanges();
            }

            // To delete data:
            using (SampleDatabase db = new SampleDatabase())
            {
                var user = db.Users.FirstOrDefault(u => u.LastName == "Smith");
                if(user != null)
                {
                    db.Users.Remove(user);
                }

                db.SaveChanges();
            }

            // To select data:
            using(SampleDatabase db = new SampleDatabase())
            {
                List<Users> users = db.Users.OrderBy(u => u.RegisteredOn).ToList();

                foreach(var u in users)
                {
                    Console.WriteLine("User {0} {1}, created {2}", u.FirstName, u.LastName, u.RegisteredOn);
                }
            }
        }
    }
}
