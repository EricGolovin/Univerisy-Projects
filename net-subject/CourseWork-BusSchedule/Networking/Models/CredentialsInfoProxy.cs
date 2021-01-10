using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_BusSchedule.Networking.Models
{
    public class CredentialsInfoProxy
    {
        public static List<CredentialsInfo> GetAll()
        {
            return Get(RequestConsts.Get.CredentialsInfo.getAll);
        }

        public static List<CredentialsInfo> Get(int personId)
        {
            return Get(String.Format(RequestConsts.Get.CredentialsInfo.getById, personId));
        }

        private static List<CredentialsInfo> Get(string request)
        {
            List<CredentialsInfo> resultList = new List<CredentialsInfo>();
            try
            {
                SqlDataReader reader = DatabaseConnection.shared.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    int busId = Convert.ToInt32(reader.GetValue(1));
                    string categoryString = Convert.ToString(reader.GetValue(2));
                    string positionString = Convert.ToString(reader.GetValue(3));
                    string firstWorkDayDateString = Convert.ToString(reader.GetValue(4));
                    int personId = Convert.ToInt32(reader.GetValue(5));

                    Bus bus = GetBus(busId);
                    Category category = new Category(categoryString);
                    Position position = new Position(positionString);
                    Person person = GetPerson(personId);

                    DateTime firstWorkDayDate = DateTime.Parse(firstWorkDayDateString);

                    if (position.type == Position.PositionType.Undentified)
                    {
                        Console.WriteLine($"Data Corruption Error: Position is Undentified for id({person.id}) - name({person.name})");
                        continue;
                    }

                    CredentialsInfo newCredentialsInfo = new CredentialsInfo(id, bus, category, position, firstWorkDayDate, person);
                    resultList.Add(newCredentialsInfo);
                }
                DatabaseConnection.shared.CloseLastConnection();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("CredentialsInfoList is Empty");
            }
            return resultList;
        }

        private static void Put(string request)
        {
            DatabaseConnection.shared.Put(request);
        }

        private static Bus GetBus(int busId)
        {
            return BusProxy.Get(busId).First();
        }

        private static Person GetPerson(int personId)
        {
            return PersonInfoProxy.Get(personId).First();
        }
    }

    public class CredentialsInfo
    {
        public int id;
        public Bus bus;
        public Category category;
        public Position position;
        public DateTime firstWorkDayDate;
        public Person person;

        public CredentialsInfo(int id, Bus bus, Category category, Position position, DateTime firstWorkDayDate, Person person)
        {
            this.id = id;
            this.bus = bus;
            this.category = category;
            this.position = position;
            this.firstWorkDayDate = firstWorkDayDate;
            this.person = person;
        }

        // Only for mocking data or to report costruction failure
        public CredentialsInfo()
        {
            this.id = -1;
        } 

        public string GetDescription()
        {
            return $"CredentialsInfo: \r\tid=({id}), \r\tbus=({bus.GetDescription()}), \r\tcategory=({category.ToString()}), \r\tposition=({position.ToString()}), \r\tfirstWorkDayDate=({firstWorkDayDate.ToString("MM-dd-yy")}), \r\tperson=({person.GetDescription()})\r\r";
        }
    }

    public struct Category
    {
        public enum CategoryType : int
        {
            Undentified = 0,
            First = 1,
            Second = 2
        }

        public readonly CategoryType type;

        public Category(string value)
        {
            switch (value)
            {
                case "1":
                    this.type = CategoryType.First;
                    break;
                case "2":
                    this.type = CategoryType.Second;
                    break;
                default:
                    this.type = CategoryType.Undentified;
                    break;
            }
        }

        public override string ToString()
        {
            switch (type)
            {
                case CategoryType.Undentified:
                    return $"Category(Undentified)";
                default:
                    return $"Category({type})";
            }
        }
    }

    public struct Position
    {
        public enum PositionType
        {
            Undentified,
            Driver,
            Conductor,
            Manager
        }

        public readonly PositionType type;

        public Position(string position)
        {
            switch (position)
            {
                case "driver":
                    type = PositionType.Driver;
                    break;
                case "conductor":
                    type = PositionType.Conductor;
                    break;
                case "manager":
                    type = PositionType.Manager;
                    break;
                default:
                    type = PositionType.Undentified;
                    break;
            }
        }

        public override string ToString()
        {
            switch (type)
            {
                case PositionType.Driver:
                    return "Position=(Driver)";
                case PositionType.Conductor:
                    return "Position=(Conductor)";
                case PositionType.Manager:
                    return "Position=(Manager)";
                case PositionType.Undentified:
                    return "Position=(Unknown)";
            }
            return "Position Error: Should not invoked";
        }

        public string GetTypeDescription()
        {
            switch (type)
            {
                case PositionType.Driver:
                    return "Driver";
                case PositionType.Conductor:
                    return "Conductor";
                case PositionType.Manager:
                    return "Manager";
                case PositionType.Undentified:
                    return "Unknown";
            }
            return "Position Error: Should not invoked";
        }
    }
}
