using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_BusSchedule.Networking.Models
{
    public class PersonInfoProxy
    {
        public static List<Person> GetAll()
        {
            return Get(RequestConsts.Get.Person.getAll);
        }

        public static List<Person> Get(int personId)
        {
            return Get(String.Format(RequestConsts.Get.Person.getById, personId));
        }

        private static List<Person> Get(string request)
        {
            List<Person> resultList = new List<Person>();
            try
            {
                SqlDataReader reader = DatabaseConnection.shared.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string name = Convert.ToString(reader.GetValue(1));
                    string address = Convert.ToString(reader.GetValue(2));
                    string homePhoneNumber = Convert.ToString(reader.GetValue(3));
                    string workPhoneNumber = Convert.ToString(reader.GetValue(4));
                    string birthdayDate = Convert.ToString(reader.GetValue(5));

                    DateTime birthdayDateTime = DateTime.Parse(birthdayDate);

                    Person newPerson = new Person(id, name, address, homePhoneNumber, workPhoneNumber, birthdayDateTime);
                    resultList.Add(newPerson);
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

        private static void Put(string request)
        {
            DatabaseConnection.shared.Put(request);
        }
    }

    public class Person
    {
        public int id;
        public string name;
        public string address;
        public string homePhoneNumber;
        public string workPhoneNumber;
        public DateTime birthdayDate;

        public Person(int id, string name, string address, string homePhoneNumber, string workPhoneNumber, DateTime birthdayDate)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.homePhoneNumber = homePhoneNumber;
            this.workPhoneNumber = workPhoneNumber;
            this.birthdayDate = birthdayDate;
        }

        public string GetDescription()
        {
            return $"Person: \r\tid=({id})\r\tname=({name}), \r\taddress=({address}), \r\thomePhoneNumber=({homePhoneNumber}), \r\tworkPhoneNumber=({workPhoneNumber}), \r\tbirthdayDate=({birthdayDate.ToString("MM-dd-yy")})\r\r";
        }
    }
}
