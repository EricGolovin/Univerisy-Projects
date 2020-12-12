using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

/*
 * Will be implemented after Manager workflow Discussion

namespace CourseWork_Atelie.Networking.SingleDependable
{
    class FabricNetworkProxy
    {
        private static readonly Shared.SQLDatabaseConnetion connection = Shared.SQLDatabaseConnetion.instance;
        public static List<Fabric> Get(string request, Independent.Manufacturer manufacturer)
        {
            List<Fabric> resultList = new List<Fabric>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string fullName = Convert.ToString(reader.GetValue(1));
                    string phoneNumber = Convert.ToString(reader.GetValue(2));
                    string email = Convert.ToString(reader.GetValue(3));

                    Client newObject = new Client(id, fullName, phoneNumber, email);
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
    class Fabric
    {
        public int id;
        public string name;
        public float width;
        public float height;
        public double price;
        public Independent.Manufacturer manufacturer;
        Fabric(int id, string name, float width, float height, double price, Independent.Manufacturer manufacturer)
        {
            this.id = id;
            this.name = name;
            this.width = width;
            this.height = height;
            this.price = price;
            this.manufacturer = manufacturer;
        } 
    }
}

*/
