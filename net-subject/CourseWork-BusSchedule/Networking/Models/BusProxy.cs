using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_BusSchedule.Networking.Models
{
    public class BusProxy
    {
        public static List<Bus> GetAll()
        {
            return Get(RequestConsts.Get.Bus.getAll);
        }

        public static List<Bus> Get(int id)
        {
            return Get(request: String.Format(RequestConsts.Get.Bus.getById, id));
        }

        private static List<Bus> Get(string request)
        {
            List<Bus> resultList = new List<Bus>();
            try
            {
                SqlDataReader reader = DatabaseConnection.shared.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string brand = Convert.ToString(reader.GetValue(1));
                    int subId = Convert.ToInt32(reader.GetValue(2));
                    double totalDistanceDriven = Convert.ToDouble(reader.GetValue(3));
                    string releaseDateString = Convert.ToString(reader.GetValue(4));

                    DateTime releaseDate = DateTime.Parse(releaseDateString);

                    Bus newBus = new Bus(id, brand, subId, totalDistanceDriven, releaseDate);
                    resultList.Add(newBus);
                }
                DatabaseConnection.shared.CloseLastConnection();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("BusList is Empty");
            }
            return resultList;
        }

        private static void Put(string request)
        {
            DatabaseConnection.shared.Put(request);
        }
    }

    public class Bus
    {
        // Id in a company database
        public int id;
        public string brand;
        // Id in a country database
        public int subId;
        public double totalDistanceDriven;
        public DateTime releaseDate;

        public Bus(int id, string brand, int subId, double totalDistanceDriven, DateTime releaseDate)
        {
            this.id = id;
            this.brand = brand;
            this.subId = subId;
            this.totalDistanceDriven = totalDistanceDriven;
            this.releaseDate = releaseDate;
        }

        public string GetDescription()
        {
            return $"Bus: \r\tid=({id}), \r\tbrand=({brand}), \r\tsubId=({subId}), \r\ttotalDistanceDriven=({totalDistanceDriven}), \r\treleaseDate=({releaseDate})\r\r";
        }
    }
}
