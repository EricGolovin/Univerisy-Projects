using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_Atelie.Networking
{
    class CutterNetworkProxy : Shared.NetworkRequest<List<Cutter>>
    {
        private readonly Shared.SQLDatabaseConnetion connection = Shared.SQLDatabaseConnetion.instance;
        public List<Cutter> Get(string request)
        {
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
            return resultList;
        }
        public void Add(string request)
        {
            connection.Insert(request);
        }
    }
    class Cutter
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
    }
}
