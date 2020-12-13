using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_Atelie.Networking.Independent
{
    class ModelNetworkProxy
    {
        private static readonly Shared.SQLDatabaseConnetion connection = Shared.SQLDatabaseConnetion.instance;
        public static List<Model> Get(string request)
        {
            List<Model> resultList = new List<Model>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string name = Convert.ToString(reader.GetValue(1));
                    int consumption = Convert.ToInt32(reader.GetValue(2));
                    double price = Convert.ToDouble(reader.GetValue(3));

                    Model newObject = new Model(id, name, consumption, price);
                    resultList.Add(newObject);
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("ModelList is Empty");
            }
            return resultList;
        }
        public static void Add(string request)
        {
            connection.Insert(request);
        }
    }
    class Model
    {
        public int id;
        public string name;
        public int consumption;
        public double price;
        public Model(int id, string name, int consumption, double price)
        {
            this.id = id;
            this.name = name;
            this.consumption = consumption;
            this.price = price;
        }
    }
}
