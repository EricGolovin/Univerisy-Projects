using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

/*
 * Will be implemented after Manager workflow Discussion

namespace CourseWork_Atelie.Networking.MultipleDependable
{
    class RecommendationNetworkProxy
    {
        private readonly Shared.SQLDatabaseConnetion connection = Shared.SQLDatabaseConnetion.instance;
        public List<Recommendation> Get(string request)
        {
            List<Recommendation> resultList = new List<Recommendation>();
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
            return resultList;
        }
        public void Add(string request)
        {
            connection.Insert(request);
        }
    }
    class Recommendation
    {
        public SingleDependable.Model model;
        private SingleDependable

        public Client(int id, string fullName, string phoneNumber, string email)
        {
            this.id = id;
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }
}

*/
