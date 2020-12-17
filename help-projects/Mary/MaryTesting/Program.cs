using System;
using System.Collections.Generic;

namespace MaryTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfObjects = 50;
            List<PhoneBook> phoneBookUsers = new List<PhoneBook>();
            List<string> names = new List<string>() {"Mary", "Sam", "Tim", "Alexandro", "Tomas", "Greemand"};

            for(int i = 0; i < numberOfObjects; i++)
            {
                Random random = new Random();
                int num = random.Next(1000);
                string nameToAdd = names[(i + names.Count) % names.Count];
                if (num % 3 == 0)
                {
                    phoneBookUsers.Add(new Person(nameToAdd, "blablabla", "+380555332"));
                } else if (num % 3 == 1)
                {
                    phoneBookUsers.Add(new Organisation(nameToAdd, "blablabla", "+353555", "5234345", "Admin"));
                } else
                {
                    phoneBookUsers.Add(new Friend(nameToAdd, "blablabla", "+395435", DateTime.Today));
                }
            }

            PrintAllUsers(phoneBookUsers);
            PrintAllUsers(FindUserByName("Tim", phoneBookUsers));
        }

        static List<PhoneBook> FindUserByName(string name, List<PhoneBook> phoneBook)
        {
            List<PhoneBook> foundUsers = new List<PhoneBook>();
            foreach (PhoneBook user in phoneBook)
            {
                if (user.GetName().ToLower() == name.ToLower())
                {
                    foundUsers.Add(user);
                }
            }
            return foundUsers;
        }

        static void PrintAllUsers(List<PhoneBook> phoneBook)
        {
            Console.WriteLine("Users from PhoneBook: \n");
            foreach (PhoneBook user in phoneBook)
            {
                Console.WriteLine(user.GetDescription());
            }
            Console.WriteLine("------------------------ \n\n");
        }
    }

    class PhoneBook
    {
        protected string name;
        protected string address;
        protected string phoneNumber;

        public string GetName()
        {
            return name;
        }

        public string GetAdress()
        {
            return address;
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public virtual string GetDescription()
        {
            return $"name = {name}, address={address}, phoneNumber={phoneNumber}";
        }
    }

    class Person : PhoneBook
    {
        public Person(string name, string address, string phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public override string GetDescription()
        {
            return $"Person: {base.GetDescription()}\r";
        }
    }

    class Organisation : PhoneBook
    {
        public string faxNumber;
        public string managerName;

        public Organisation(string name, string address, string phoneNumber, string faxNumber, string managerName)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.faxNumber = faxNumber;
            this.managerName = managerName;
        }

        public override string GetDescription()
        {
            return $"Organisation: {base.GetDescription()}, faxNumber={faxNumber}, managerName={managerName}\r";
        }
    }

    class Friend : PhoneBook
    {
        public DateTime birthDate;

        public Friend(string name, string address, string phoneNumber, DateTime birthDate)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.birthDate = birthDate;
        }

        public override string GetDescription()
        {
            return $"Friend: {base.GetDescription()}, birthDate={birthDate.ToString("dd-MM-yy")}\r";
        }
    }
}
