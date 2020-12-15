using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ExtensionMethods;

namespace CourseWork_Atelie.Networking.Independent
{
    public class ClientNetworkProxy 
    {
        public static List<Client> Get(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            List<Client> resultList = new List<Client>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string fullName = Convert.ToString(reader.GetValue(1));
                    string phoneNumber = Convert.ToString(reader.GetValue(2));
                    string email = Convert.ToString(reader.GetValue(3));

                    Client newObject = new Client(id, fullName, phoneNumber, email);
                    resultList.Add(newObject);
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("ModelList is Empty");
            }
            connection.closeConnection();
            return resultList;
        }

        public static Client Add(string fullName, string phoneNumber, string email)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            string formattedPhoneNumber = phoneNumber.RemoveWhitespace();
            string formattedEmail = email.RemoveWhitespace();
            Client newClient = new Client(Services.IdBuilderService.GetRandomId(), fullName, phoneNumber, email);
            connection.Insert(String.Format(Shared.RequestConsts.Put.Independent.putClientRequest, newClient.id, fullName, formattedPhoneNumber, formattedEmail));
            return newClient;
        }
        public static void Add(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            connection.Insert(request);
        }
    }
    public class Client
    {
        public int id;
        public string fullName;
        public string phoneNumber;
        public string email;

        public Client(int id, string fullName, string phoneNumber, string email)
        {
            this.id = id;
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }
}
