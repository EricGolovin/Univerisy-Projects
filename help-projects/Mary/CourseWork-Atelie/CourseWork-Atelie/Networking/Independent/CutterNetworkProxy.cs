using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_Atelie.Networking.Independent
{
    public class CutterNetworkProxy 
    {
        public static List<Cutter> Get(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            List<Cutter> resultList = new List<Cutter>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string fullName = Convert.ToString(reader.GetValue(1));
                    double salary = Convert.ToDouble(reader.GetValue(2));
                    int numberOfOrders = Convert.ToInt32(reader.GetValue(3));

                    Cutter newObject = new Cutter(id, fullName, salary, numberOfOrders);
                    resultList.Add(newObject);
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("ModelList is Empty");
            }
            connection.closeConnection();
            return resultList;
        }

        public static List<Cutter> GetAll()
        {
            return Get(Shared.RequestConsts.Get.Cutter.getAllRequest);
        }
        public static void Add(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            connection.Insert(request);
        }

        public static void UpdateNumberOfOders(int id, int newValue)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            connection.Update(String.Format(Shared.RequestConsts.Update.Cutter.updateNumOfOrdersByIdRequest, newValue, id));
        }
    }
    public class Cutter
    {
        public int id;
        public string fullName;
        public double salary;
        public int numberOfOrders;

        public Cutter(int id, string fullName, double salary, int numberOfOrders)
        {
            this.id = id;
            this.fullName = fullName;
            this.salary = salary;
            this.numberOfOrders = numberOfOrders;
        }

        public string GetDescription()
        {
            return $"Cutter: {id}, {fullName}, {salary}, {numberOfOrders}";
        }
    }
}
