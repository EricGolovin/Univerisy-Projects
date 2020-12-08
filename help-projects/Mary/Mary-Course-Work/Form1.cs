using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mary_Course_Work
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=mary-course-work;Integrated Security=True";
            int number;

            SqlConnection connection = new SqlConnection(connectionString);

            string sqlExpressionInsert = "INSERT INTO Users (Id, Name, Age) VALUES (1, 'Tim', 18)";
            string sqlExpressionUpdate = "UPDATE Users SET Age=20 WHERE Name='Tim'";
            string sqlExpressionDelete = "DELETE  FROM Users WHERE Name='Tim'";
            string sqlExpressionSelect = "SELECT * FROM Users";
            
            try
            {
                connection.Open();
                Console.WriteLine("Connection Opened");

                Console.WriteLine("Connection Properties:");
                Console.WriteLine("\tConnection Line: {0}", connection.ConnectionString);
                Console.WriteLine("\tDataBase: {0}", connection.Database);
                Console.WriteLine("\tServer: {0}", connection.DataSource);
                Console.WriteLine("\tServer Version: {0}", connection.ServerVersion);
                Console.WriteLine("\tStatus: {0}", connection.State);
                Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
                /*
                                SqlCommand commandInsert = new SqlCommand(sqlExpressionInsert, connection);
                                number = commandInsert.ExecuteNonQuery();
                                Console.WriteLine($"Number of objects inserted: {number}");

                                SqlCommand commandUpdate = new SqlCommand(sqlExpressionUpdate, connection);
                                number = commandUpdate.ExecuteNonQuery();
                                Console.WriteLine($"Number of objects updated: {number}");
                */
                SqlCommand commandDelete = new SqlCommand(sqlExpressionDelete, connection);
                number = commandDelete.ExecuteNonQuery();
                Console.WriteLine($"Number of objects deleted: {number}");

            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }

            connection.Close();
            Console.WriteLine("ConnectionClosed");
        }
    }
}
