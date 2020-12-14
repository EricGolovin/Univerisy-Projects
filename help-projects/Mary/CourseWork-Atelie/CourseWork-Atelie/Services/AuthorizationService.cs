using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace CourseWork_Atelie.Services
{
    class AuthorizationService
    {
        public List<OnDeviceUser> savedUsers = AuthorizationConsts.users;
        public string usernameToCheck = "";
        public AuthorizationService() { }

        public bool UserExists(string username)
        {
            usernameToCheck = "";
            usernameToCheck = username.RemoveWhitespace();
            bool resultBool = false;
            foreach(OnDeviceUser user in savedUsers)
            {
                if (String.Equals(usernameToCheck, user.username, StringComparison.CurrentCulture))
                {
                    resultBool = true;
                    break;
                }
            }
            return resultBool;
        }

        public AccessType ValidatePassword(string password)
        {
            AccessType resultAccessType = AccessType.user;
            if (usernameToCheck != "")
            {
                foreach (OnDeviceUser user in savedUsers)
                {
                    if (String.Equals(usernameToCheck, user.username, StringComparison.CurrentCulture) && String.Equals(password, user.password, StringComparison.CurrentCulture))
                    {
                        resultAccessType = user.level;
                        break;
                    }
                }
            } else
            {
                Console.WriteLine("Error: Password Validation AccessType - UsernameToCheck is EMPTY");
            }
            return resultAccessType;
        }

        private class AuthorizationConsts
        {
            public static List<OnDeviceUser> users = new List<OnDeviceUser>() { new OnDeviceUser("admin", "admin", AccessType.admin), new OnDeviceUser("client", "client", AccessType.user) };
        }
    }

    class OnDeviceUser
    {
        public string username;
        public string password;
        public readonly AccessType level;

        public OnDeviceUser(string username, string password, AccessType level)
        {
            this.username = username.RemoveWhitespace();
            this.password = password.RemoveWhitespace();
            this.level = level;
        }


    }

    public enum AccessType {
        admin,
        user
    }
}
