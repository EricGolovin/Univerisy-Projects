using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork_BusSchedule.Services;

namespace CourseWork_BusSchedule.Models
{
    class RegistrationModel : BaseModel
    {
        private string name = "";
        private string password = "";
        public override void Load()
        {

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

        public UserType ValidateUser()
        {
            switch (CredentialsManagerService.shared.ValidateUser(name, password))
            {
                case CredentialsManagerService.AccessLevel.Admin:
                    return UserType.Admin;
                case CredentialsManagerService.AccessLevel.User:
                    return UserType.User;
                case CredentialsManagerService.AccessLevel.Unknown:
                    return UserType.NoUser;
            }
            return UserType.NoUser;
        }
    }

    public enum UserType
    {
        User,
        Admin,
        NoUser
    }
}
