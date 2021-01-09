using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_BusSchedule.Networking
{
    public class RequestConsts
    {
        public class Get
        {
            public class Bus
            {
                public static string getAll = "SELECT * FROM Buses;";
                public static string getById = $"SELECT * FROM Buses WHERE Bort_IN_Bus = {0};";
            }
            public class Person
            {
                public static string getAll = "SELECT * FROM Personal_Info;";
                public static string getById = $"SELECT * FROM Personal_Info WHERE Personal_Number = {0};";
            }

            public class Itinerary
            {
                public static string getAll = "SELECT * FROM Itinerary;";
                public static string getById = $"SELECT * FROM Itinerary WHERE IN_Route = {0};";
            }

            public class CredentialsInfo
            {
                public static string getAll = "SELECT * FROM Credentials_Info;";
                public static string getById = $"SELECT * FROM Credentials_Info WHERE Personnel_Number = {0};";
            }
        }

        public class Put
        {

        }
    }
}
