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
        public static List<Person> Get(string request)
        {
            List<Person> resultList = new List<Person>();
            try
            {
                SqlDataReader reader = DatabaseConnection.shared.Get(request);
                while (reader.Read())
                {
                    string personalPhoneNumber = Convert.ToString(reader.GetValue(0));
                    string name = Convert.ToString(reader.GetValue(1));
                    string address = Convert.ToString(reader.GetValue(2));
                    string homePhoneNumber = Convert.ToString(reader.GetValue(3));
                    string workPhoneNumber = Convert.ToString(reader.GetValue(4));
                    string birthdayDate = Convert.ToString(reader.GetValue(5));

                    DateTime birthdayDateTime = DateTime.Parse(birthdayDate);

                    Person newPerson = new Person(personalPhoneNumber, name, address, homePhoneNumber, workPhoneNumber, birthdayDateTime);
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

    }

    public class Person
    {
        public string personalPhoneNumber;
        public string name;
        public string address;
        public string homePhoneNumber;
        public string workPhoneNumber;
        public DateTime birthdayDate;

        public Person(string personalPhoneNumber, string name, string address, string homePhoneNumber, string workPhoneNumber, DateTime birthdayDate)
        {
            this.personalPhoneNumber = personalPhoneNumber;
            this.name = name;
            this.address = address;
            this.homePhoneNumber = homePhoneNumber;
            this.workPhoneNumber = workPhoneNumber;
            this.birthdayDate = birthdayDate;
        }

        public string GetDescription()
        {
            return $"Person: \r\tname=({name}), \r\taddress=({address}), \r\thomePhoneNumber=({homePhoneNumber}), \r\tworkPhoneNumber=({workPhoneNumber}), \r\tbirthdayDate=({birthdayDate.ToString("MM-dd-yy")})\r\r";
        }
    }
}
