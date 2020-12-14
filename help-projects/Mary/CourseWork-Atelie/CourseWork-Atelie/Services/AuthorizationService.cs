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
        private string usernameToCheck = "";
        private bool isPasswordValid = false;
        public AuthorizationService() { }

        public bool UserExists(string username)
        {
            usernameToCheck = "";
            isPasswordValid = false;
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

        public bool ValidatePassword(string password) {
            if (usernameToCheck != "")
            {
                isPasswordValid = false;
                foreach (OnDeviceUser user in savedUsers)
                {
                    if (String.Equals(usernameToCheck, user.username, StringComparison.CurrentCulture) && String.Equals(password, user.password, StringComparison.CurrentCulture))
                    {
                        isPasswordValid = true;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: Password Validation - UsernameToCheck is EMPTY");
            }
            return isPasswordValid;
        }
        public AccessType GetUserAccessType()
        {
            AccessType resultAccessType = AccessType.user;
            if (usernameToCheck != "" && isPasswordValid)
            {
                foreach (OnDeviceUser user in savedUsers)
                {
                    if (String.Equals(usernameToCheck, user.username, StringComparison.CurrentCulture))
                    {
                        resultAccessType = user.level;
                        break;
                    }
                }
            } else
            {
                if (usernameToCheck == "")
                {
                    Console.WriteLine("Error: AccessType - UsernameToCheck is EMPTY");
                }
                if (!isPasswordValid)
                {
                    Console.WriteLine("Error: AccessType - Password is NOT VALID");
                }
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
