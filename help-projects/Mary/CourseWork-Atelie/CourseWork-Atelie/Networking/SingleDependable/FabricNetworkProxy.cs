using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_Atelie.Networking.SingleDependable
{
    public class FabricNetworkProxy
    {
        public static List<Fabric> Get(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            List<Fabric> resultList = new List<Fabric>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string name = Convert.ToString(reader.GetValue(1));
                    double length = Convert.ToDouble(reader.GetValue(2));
                    double price = Convert.ToDouble(reader.GetValue(3));
                    int manufacturerId = Convert.ToInt32(reader.GetValue(4));
                    string photoLink = Convert.ToString(reader.GetValue(5));
                    Independent.Manufacturer newManufacturer = getManufacturerById(manufacturerId);

                    Fabric newObject = new Fabric(id, name, length, price, newManufacturer, photoLink);
                    resultList.Add(newObject);
                }
                connection.closeConnection();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("ModelList is Empty");
            }
            return resultList;
        }
        public static void Add(Fabric fabric)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            Independent.ManufacturerNetworkProxy.Add(fabric.manufacturer);
            connection.Insert(String.Format(Shared.RequestConsts.Put.Dependable.putFabricRequest, fabric.id, fabric.name, fabric.length, fabric.price, fabric.manufacturer.id, fabric.photoLink));
        }

        public static List<Fabric> GetAll()
        {
            return Get(Shared.RequestConsts.Get.Fabric.getAllRequest);
        }

        public static void UpdateLengthValueById(int id, double newValue)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            connection.Update(String.Format(Shared.RequestConsts.Update.Fabric.updateLenghtByIdRequest, newValue, id));
        }

        private static Independent.Manufacturer getManufacturerById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.Manufacturer.getByIdRequest, id);
            List<Independent.Manufacturer> newManufacturers = Independent.ManufacturerNetworkProxy.Get(request);
            return newManufacturers.First();
        }
    }
    public class Fabric
    {
        public int id;
        public string name;
        public double length;
        public double price;
        public readonly Independent.Manufacturer manufacturer;
        public string photoLink;
        public Fabric(int id, string name, double length, double price, Independent.Manufacturer manufacturer, string photoLink)
        {
            this.id = id;
            this.name = name;
            this.length = length;
            this.price = price;
            this.manufacturer = manufacturer;
            this.photoLink = photoLink;
        } 

        public int getManufacturerId()
        {
            return manufacturer.id;
        }
    }
}
