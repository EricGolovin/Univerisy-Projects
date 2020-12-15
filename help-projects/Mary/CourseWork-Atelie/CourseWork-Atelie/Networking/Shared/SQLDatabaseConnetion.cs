using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_Atelie.Networking.Shared
{
    class SQLDatabaseConnetion
    {
        public SQLDatabaseConnetion() { }

        private static string databaseConnectionConst = @"Data Source=DESKTOP-SOKIGIV;Initial Catalog=atelie-mary;Integrated Security=True";
        private SqlConnection connection = new SqlConnection(databaseConnectionConst);

        public SqlDataReader Get(string command)
        {
            connection.Open();
            Console.WriteLine("Connection opened");
            SqlCommand newCommand = new SqlCommand(command, connection);
            SqlDataReader reader = newCommand.ExecuteReader();
            Console.WriteLine("Connection closed");
            return reader;
        }

        public void Insert(string command)
        {
            int counter;
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened");

                SqlCommand newCommand = new SqlCommand(command, connection);

                counter = newCommand.ExecuteNonQuery();
                Console.WriteLine($"Number of objects inserted: {counter}");

                connection.Close();
                Console.WriteLine("Connection closed");
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void Update(string command)
        {
            int counter;
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened");

                SqlCommand newCommand = new SqlCommand(command, connection);

                counter = newCommand.ExecuteNonQuery();
                Console.WriteLine($"Number of objects updated: {counter}");

                connection.Close();
                Console.WriteLine("Connection closed");
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void closeConnection()
        {
            connection.Close();
        }
    }
}
