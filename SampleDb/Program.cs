using System;
using System.Data.SqlClient;

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
        }
    }
}
