﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork_Atelie.Networking.Independent
{
    public class ModelNetworkProxy
    {
        public static List<Model> Get(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            List<Model> resultList = new List<Model>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string name = Convert.ToString(reader.GetValue(1));
                    double consumption = Convert.ToInt32(reader.GetValue(2));
                    double price = Convert.ToDouble(reader.GetValue(3));
                    string photoLink = Convert.ToString(reader.GetValue(4));

                    Model newObject = new Model(id, name, consumption, price, photoLink);
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
        public static void Add(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            connection.Insert(request);
        }

        public static List<Model> GetAll()
        {
            return Get(Shared.RequestConsts.Get.Model.getAllRequest);
        }
    }
    public class Model
    {
        public int id;
        public string name;
        public double consumption;
        public double price;
        public string photoLink;
        public Model(int id, string name, double consumption, double price, string photoLink)
        {
            this.id = id;
            this.name = name;
            this.consumption = consumption;
            this.price = price;
            this.photoLink = photoLink;
        }

        public string GetDescription()
        {
            return $"Model: {id}, {name}, {consumption}, {price}, {photoLink}";
        }
    }
}
