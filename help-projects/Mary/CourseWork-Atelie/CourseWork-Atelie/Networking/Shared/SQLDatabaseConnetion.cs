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
        // Singleton
        public static readonly SQLDatabaseConnetion instance = new SQLDatabaseConnetion();

        private SQLDatabaseConnetion() { }

        private static string databaseConnectionConst = @"Data Source=DESKTOP-SOKIGIV;Initial Catalog=atelie-mary;Integrated Security=True";
        private static SqlConnection connection = new SqlConnection(databaseConnectionConst);

        public SqlDataReader Get(string command)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
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
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
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

        public void closeConnection()
        {
            connection.Close();
        }
    }
}
