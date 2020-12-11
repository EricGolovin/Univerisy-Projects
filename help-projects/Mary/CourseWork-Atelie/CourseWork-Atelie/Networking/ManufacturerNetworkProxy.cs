using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_Atelie.Networking
{
    class ManufacturerNetworkProxy : Shared.NetworkRequest<List<Manufacturer>>
    {
        private readonly Shared.SQLDatabaseConnetion connection = Shared.SQLDatabaseConnetion.instance;
        public List<Manufacturer> Get(string request)
        {
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
            return resultList;
        }
        public void Add(string request)
        {
            connection.Insert(request);
        }
    }
    class Manufacturer
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
