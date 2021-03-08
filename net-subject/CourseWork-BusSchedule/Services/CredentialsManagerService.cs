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
        public AccessLevel AddUser(string username, string password, string accessLevelValue)
        {
            foreach (User user in allUsers)
            {
                if (user.ValidateUsername(username))
                {
                    Console.WriteLine($"CredentialManagerService Error: User with ({username}) already exists");
                    return AccessLevel.Unknown;
                }
            }
            KeyValuePair<string, string> userData = ConvertCredentials(username, password);
            AccessLevel accessLevel = (AccessLevel) Enum.Parse(typeof(AccessLevel), accessLevelValue);
            User newUser = new User(userData.Key, userData.Value, accessLevel);
            allUsers.Add(newUser);
            return newUser.accessLevel;
        }

        public AccessLevel RemoveUser(string username)
        {
            int counter = 0;
            foreach (User user in allUsers)
            {
                if (user.ValidateUsername(username))
                {
                    allUsers.RemoveAt(counter);
                    return user.accessLevel;
                }
                counter += 1;
            }
            Console.WriteLine($"CredentialManagerService Error: No user exists with ({username})");
            return AccessLevel.Unknown;
        }

        public AccessLevel ValidateUser(string username, string password)
        {
            foreach (User user in allUsers)
            {
                if (user.Validate(ConvertCredentials(username, password)))
                {
                    return user.accessLevel;
                }
            }
            return AccessLevel.Unknown;
        }

        public bool UserExists(string username)
        {
            foreach (User user in allUsers)
            {
                if (user.ValidateUsername(username))
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
        public enum AccessLevel : ushort
        {
            Unknown = 0,
            User = 1,
            Admin = 2
        }
        private struct User
        {
            private string username;
            private string password;
            public readonly AccessLevel accessLevel;

            public User(string username, string password, AccessLevel accessLevel)
            {
                this.username = username;
                this.password = password;
                this.accessLevel = accessLevel;
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
