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
                    string position = Convert.ToString(reader.GetValue(3));
                    string firstWorkDayDateString = Convert.ToString(reader.GetValue(4));
                    int personId = Convert.ToInt32(reader.GetValue(5));

                    Bus bus = GetBus(busId);
                    Category category = new Category(categoryString);
                    Person person = GetPerson(personId);

                    DateTime firstWorkDayDate = DateTime.Parse(firstWorkDayDateString);

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
        public string position;
        public DateTime firstWorkDayDate;
        public Person person;

        public CredentialsInfo(int id, Bus bus, Category category, string position, DateTime firstWorkDayDate, Person person)
        {
            this.id = id;
            this.bus = bus;
            this.category = category;
            this.position = position;
            this.firstWorkDayDate = firstWorkDayDate;
            this.person = person;
        }

        public string GetDescription()
        {
            return $"CredentialsInfo: \r\tid=({id}), \r\tbus=({bus.GetDescription()}), \r\tcategory=({category.ToString()}), \r\tposition=({position}), \r\tfirstWorkDayDate=({firstWorkDayDate.ToString("MM-dd-yy")}), \r\tperson=({person.GetDescription()})\r\r";
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
}
