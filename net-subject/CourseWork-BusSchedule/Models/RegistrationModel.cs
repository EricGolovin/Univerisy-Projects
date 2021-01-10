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
        private List<Networking.Models.CredentialsInfo> usersCredentials;
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

        public override void Load()
        {
            SetupUsers();
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

        // Execute only after User Validation success
        public Networking.Models.CredentialsInfo GetLoggedUser()
        {
            if (ValidateUser())
            {
                foreach (Networking.Models.CredentialsInfo credentialInfo in usersCredentials)
                {
                    bool usernameEqual = credentialInfo.person.name.RemoveWhitespaces() == name.RemoveWhitespaces();
                    
                    List<Networking.Models.Position.PositionType> userPositions = Builders.PositionBuilder.BuildFrom(CredentialsManagerService.shared.ValidateUser(name, password));
                    bool positionEqual = false;
                    foreach (Networking.Models.Position.PositionType position in userPositions)
                    {
                        if (credentialInfo.position.type == position)
                        {
                            positionEqual = true;
                            break;
                        }
                    }
                    if (usernameEqual && positionEqual)
                    {
                        return credentialInfo;
                    }
                }
            }
            Console.WriteLine("GetLoggedUser Error: GetLoggedUser was executed before ValidateUser method, should not happen");
            Networking.Models.CredentialsInfo failedCredentialsInfo = new Networking.Models.CredentialsInfo();
            return failedCredentialsInfo;
        }

        private void SetupUsers()
        {
            usersCredentials = Networking.Models.CredentialsInfoProxy.GetAll();

            foreach (Networking.Models.CredentialsInfo credentialInfo in usersCredentials)
            {
                Dictionary<string, string> userData = Builders.UserBuilder.BuildFrom(credentialInfo);
                string username = "";
                string password = "";
                string accessLevel = "";
                try
                {
                    userData.TryGetValue(Builders.UserDataKeys.kUsername, out username);
                    userData.TryGetValue(Builders.UserDataKeys.kPassword, out password);
                    userData.TryGetValue(Builders.UserDataKeys.kAccessLevel, out accessLevel);
                } catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                CredentialsManagerService.shared.AddUser(username, password, accessLevel);
            }

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
