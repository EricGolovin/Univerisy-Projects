using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_BusSchedule.Services
{
    using Extensions;
    public partial class CredentialsManagerService
    {
        public static CredentialsManagerService shared = new CredentialsManagerService();
        private CredentialsManagerService() { }

        private List<User> allUsers = new List<User>();
        public bool AddUser(string username, string password)
        {
            foreach (User user in allUsers)
            {
                if (user.ValidateUsername(username))
                {
                    Console.WriteLine($"CredentialManagerService Error: User with ({username}) already exists");
                    return false;
                }
            }
            allUsers.Add(new User(ConvertCredentials(username, password)));
            return true;
        }

        public bool RemoveUser(string username)
        {
            int counter = 0;
            foreach (User user in allUsers)
            {
                if (user.ValidateUsername(username))
                {
                    allUsers.RemoveAt(counter);
                    return true;
                }
                counter += 1;
            }
            Console.WriteLine($"CredentialManagerService Error: No user exists with ({username})");
            return false;
        }

        public bool ValidateUser(string username, string password)
        {
            foreach (User user in allUsers)
            {
                if (user.Validate(ConvertCredentials(username, password)))
                {
                    return true;
                }
            }
            return false;
        }

        private KeyValuePair<String, String> ConvertCredentials(string username, string password)
        {
            return new KeyValuePair<string, string>(username.RemoveWhitespaces(), password.RemoveWhitespaces());
        }
    }

    partial class CredentialsManagerService
    {
        private struct User
        {
            string username;
            string password;

            public User(string username, string password)
            {
                this.username = username;
                this.password = password;
            }
            
            public User(KeyValuePair<string, string> pair)
            {
                this.username = pair.Key;
                this.password = pair.Value;
            }

            public bool Validate(string username, string password)
            {
                return username == this.username && password == this.password;
            }

            public bool Validate(KeyValuePair<string, string> pair)
            {
                return username == pair.Key && password == pair.Value;
            }

            public bool ValidateUsername(string username)
            {
                return username == this.username;
            }

            public bool ValidatePassword(string password)
            {
                return password == this.password;
            }
        }
    }
}
