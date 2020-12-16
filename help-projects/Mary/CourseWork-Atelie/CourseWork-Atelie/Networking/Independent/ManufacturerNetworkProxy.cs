using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_Atelie.Networking.Independent
{
    public class ManufacturerNetworkProxy 
    {
        public static List<Manufacturer> Get(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            List<Manufacturer> resultList = new List<Manufacturer>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string firmName = Convert.ToString(reader.GetValue(1));
                    string country = Convert.ToString(reader.GetValue(2));

                    Manufacturer newObject = new Manufacturer(id, firmName, country);
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
        public static void Add(Manufacturer manufacturer)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            connection.Insert(String.Format(Shared.RequestConsts.Put.Independent.putManufacturerRequest, manufacturer.id, manufacturer.firmName, manufacturer.country));
        }
        public static List<Manufacturer> GetAll()
        {
            return Get(Shared.RequestConsts.Get.Manufacturer.getAllRequest);
        }
    }
    public class Manufacturer
    {
        public int id;
        public string firmName;
        public string country;

        public Manufacturer(int id, string firmName, string country)
        {
            this.id = id;
            this.firmName = firmName;
            this.country = country;
        }
    }
}
