using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork_BusSchedule.Services;
using CourseWork_BusSchedule.Extensions;

namespace CourseWork_BusSchedule.Models
{
    class RegistrationModel : BaseModel
    {
        private enum UserType
        {
            User,
            Admin,
            Unknown,
            NoUser
        }

        private string name = "";
        private string password = "";
        public override void Load()
        {
            CredentialsManagerService.shared.AddUser("Alex", "", "1");
            CredentialsManagerService.shared.AddUser("Antonio", "admin", "2");
        }

        public string GetUsername()
        {
            return name;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetName(string newName)
        {
            name = newName;
            password = "";
        }

        public void SetPassword(string newPassword)
        {
            password = newPassword;
        }

        public bool PasswordRequired()
        {
            return CheckUserStatus() == UserType.Unknown ? true : false;
        }

        public bool LoginAllowed()
        {
            if (CheckUserStatus() == UserType.User && name.RemoveWhitespaces() != "")
            {
                return true;
            }
            return name.RemoveWhitespaces() != "" && password.RemoveWhitespaces() != "";
        }

        public bool ValidateUser() {
            UserType userStatus = CheckUserStatus();
            return userStatus == UserType.Admin || userStatus == UserType.User;
        }

        private UserType CheckUserStatus()
        {
            switch (CredentialsManagerService.shared.ValidateUser(name, password))
            {
                case CredentialsManagerService.AccessLevel.Admin:
                    return UserType.Admin;
                case CredentialsManagerService.AccessLevel.User:
                    return UserType.User;
                case CredentialsManagerService.AccessLevel.Unknown:
                    return CredentialsManagerService.shared.UserExists(name) ? UserType.Unknown : UserType.NoUser;
            }
            return UserType.NoUser;
        }
    }


}
