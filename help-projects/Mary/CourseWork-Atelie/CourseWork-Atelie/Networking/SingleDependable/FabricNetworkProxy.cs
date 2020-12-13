using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
                    string name = Convert.ToString(reader.GetValue(1));
                    double width = Convert.ToDouble(reader.GetValue(2));
                    double height = Convert.ToDouble(reader.GetValue(3));
                    double price = Convert.ToDouble(reader.GetValue(3));
                    int manufacturerId = Convert.ToInt32(reader.GetValue(4));
                    Independent.Manufacturer newManufacturer = getManufacturerById(manufacturerId);

                    Fabric newObject = new Fabric(id, name, width, height, price, newManufacturer);
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

        private static Independent.Manufacturer getManufacturerById(int id)
        {
            string request = String.Format(Shared.RequestConsts.getCustomerRequest, id);
            List<Independent.Manufacturer> newManufacturers = Independent.ManufacturerNetworkProxy.Get(request);
            return newManufacturers.First();
        }
    }
    class Fabric
    {
        public int id;
        public string name;
        public double width;
        public double height;
        public double price;
        public readonly Independent.Manufacturer manufacturer;
        public Fabric(int id, string name, double width, double height, double price, Independent.Manufacturer manufacturer)
        {
            this.id = id;
            this.name = name;
            this.width = width;
            this.height = height;
            this.price = price;
            this.manufacturer = manufacturer;
        } 

        public int getManufacturerId()
        {
            return manufacturer.id;
        }
    }
}
