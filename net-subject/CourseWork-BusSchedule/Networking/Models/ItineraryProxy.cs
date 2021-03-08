using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_BusSchedule.Networking.Models
{
    public class ItineraryProxy
    {
        public static List<Itinerary> GetAll()
        {
            return Get(RequestConsts.Get.Itinerary.getAll);
        }

        public static List<Itinerary> Get(int id)
        {
            return Get(request: String.Format(RequestConsts.Get.Itinerary.getById, id));
        }

        private static List<Itinerary> Get(string request)
        {
            List<Itinerary> resultList = new List<Itinerary>();
            try
            {
                SqlDataReader reader = DatabaseConnection.shared.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string itinerary = Convert.ToString(reader.GetValue(1));
                    double routeLength = Convert.ToDouble(reader.GetValue(2));
                    double averageTime = Convert.ToDouble(reader.GetValue(3));
                    int routesNumber = Convert.ToInt32(reader.GetValue(4));

                    Itinerary newItinerary = new Itinerary(id, itinerary, routeLength, averageTime, routesNumber);
                    resultList.Add(newItinerary);
                }
                DatabaseConnection.shared.CloseLastConnection();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("ItineraryList is Empty");
            }
            return resultList;
        }

        private static void Put(string request)
        {
            DatabaseConnection.shared.Put(request);
        }
    }

    public class Itinerary
    {
        public int id;
        public string itinerary;
        public double routeLength;
        public double averageTime;
        public int routesNumber;

        public Itinerary(int id, string itinerary, double routeLength, double averageTime, int routesNumber)
        {
            this.id = id;
            this.itinerary = itinerary;
            this.routeLength = routeLength;
            this.averageTime = averageTime;
            this.routesNumber = routesNumber;
        }

        public string GetDescription()
        {
            return $"Itinerary: \r\tid=({id}), \r\titinerary=({itinerary}), \r\trouteLength=({routeLength}), \r\taverageTime=({averageTime}), \r\troutesNumber=({routesNumber})\r\r";
        }
    }
}
