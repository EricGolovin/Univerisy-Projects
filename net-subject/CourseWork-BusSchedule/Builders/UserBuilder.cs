using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork_BusSchedule.Networking.Models;
using CourseWork_BusSchedule.Services;

namespace CourseWork_BusSchedule.Builders
{
    class UserBuilder
    {
        public static Dictionary<string, string> BuildUserFrom(Networking.Models.CredentialsInfo userInfo)
        {
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            dataDictionary.Add(UserDataKeys.kUsername, userInfo.person.name);
            switch (userInfo.position.type)
            {
                case Position.PositionType.Driver:
                case Position.PositionType.Conductor:
                    dataDictionary.Add(UserDataKeys.kAccessLevel, Convert.ToString((int)CredentialsManagerService.AccessLevel.User));
                    dataDictionary.Add(UserDataKeys.kPassword, "");
                    break;
                case Position.PositionType.Manager:
                    dataDictionary.Add(UserDataKeys.kAccessLevel, Convert.ToString((int)CredentialsManagerService.AccessLevel.Admin));
                    dataDictionary.Add(UserDataKeys.kPassword, "admin");
                    break;
            }

            return dataDictionary;
        }
    }

    public struct UserDataKeys
    {
        public static string kUsername = "username";
        public static string kPassword = "password";
        public static string kAccessLevel = "accesslevel";
    }
}
