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
        public static SQLDatabaseConnetion shared = new SQLDatabaseConnetion();
        private SQLDatabaseConnetion() { }

        private static string databaseConnectionConst = @"Data Source=DESKTOP-BOOTCAMP7633;Initial Catalog=Transportation;Integrated Security=True";
        private List<SqlConnection> connections = new List<SqlConnection>();

        public SqlDataReader Get(string command)
        {
            SqlConnection connection = new SqlConnection(databaseConnectionConst);
            connections.Add(connection);
            connection.Open();
            SqlCommand newCommand = new SqlCommand(command, connection);
            SqlDataReader reader = newCommand.ExecuteReader();
            return reader;
        }

        public void Put(string command)
        {
            SqlConnection connection = new SqlConnection(databaseConnectionConst);
            connections.Add(connection);
            int counter;
            try
            {
                connection.Open();
                SqlCommand newCommand = new SqlCommand(command, connection);
                counter = newCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void CloseAllConnection() 
        {
            foreach(SqlConnection connection in connections) {
                connection.Close();
            }
            connections.Clear();
        }
    }
}
