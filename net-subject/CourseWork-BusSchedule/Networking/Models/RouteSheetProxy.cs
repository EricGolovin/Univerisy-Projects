using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_BusSchedule.Networking.Models
{
    public class RouteSheetProxy
    {
        private static List<RouteSheet> Get(string request)
        {
            List<RouteSheet> resultList = new List<RouteSheet>();
            try
            {
                SqlDataReader reader = DatabaseConnection.shared.Get(request);
                while (reader.Read())
                {
                    int credentialsInfoId = Convert.ToInt32(reader.GetValue(0));
                    int itineraryId = Convert.ToInt32(reader.GetValue(1));
                    string routeDateString = Convert.ToString(reader.GetValue(2));
                    string driverName = Convert.ToString(reader.GetValue(3));
                    string conductorName = Convert.ToString(reader.GetValue(4));
                    int quantity = Convert.ToInt32(reader.GetValue(5));

                    CredentialsInfo credentialsInfo = GetCredentialsInfo(credentialsInfoId);
                    Itinerary itinerary = GetItinerary(itineraryId);

                    DateTime routeDate = DateTime.Parse(routeDateString);
                    RouteSheet newRouteSheet = new RouteSheet(credentialsInfo, itinerary, routeDate, driverName, conductorName, quantity);
                    resultList.Add(newRouteSheet);
                }
                DatabaseConnection.shared.CloseLastConnection();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("PersonList is Empty");
            }
            return resultList;
        }

        private static CredentialsInfo GetCredentialsInfo(int credentialsInfoId)
        {
            return CredentialsInfoProxy.Get(credentialsInfoId).First();
        }

        private static Itinerary GetItinerary(int itineraryId)
        {
            return ItineraryProxy.Get(itineraryId).First();
        }

        private static void Put(string request)
        {
            DatabaseConnection.shared.Put(request);
        }
    }

    public class RouteSheet
    {
        public CredentialsInfo credentialsInfo;
        public Itinerary itinerary;
        public DateTime routeDate;
        public string driverName;
        public string conductorName;
        public int quantity;

        public RouteSheet(CredentialsInfo credentialsInfo, Itinerary itinerary, DateTime routeDate, string driverName, string conductorName, int quantity)
        {
            this.credentialsInfo = credentialsInfo;
            this.itinerary = itinerary;
            this.routeDate = routeDate;
            this.driverName = driverName;
            this.conductorName = conductorName;
            this.quantity = quantity;
        }

        public string GetDescription()
        {
            return $"RouteSheet: \r\tcredentialsInfo=({credentialsInfo.GetDescription()}), \r\titinerary=({itinerary.GetDescription()}), \r\trouteDate={(routeDate.ToString("MM-dd-yy"))} \r\tdriverName=({driverName}), \r\tconductorName=({conductorName}), \r\tquantity=({quantity})\r\r";
        }
    }
}
