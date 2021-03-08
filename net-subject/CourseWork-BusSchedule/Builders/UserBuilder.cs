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
        public static Dictionary<string, string> BuildFrom(Networking.Models.CredentialsInfo userInfo)
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

    class PositionBuilder
    {
        public static List<Position.PositionType> BuildFrom(CredentialsManagerService.AccessLevel accessLevel)
        {
            List<Position.PositionType> resultList = new List<Position.PositionType>();
            switch (accessLevel)
            {
                case CredentialsManagerService.AccessLevel.Admin:
                    resultList.Add(Position.PositionType.Manager);
                    return resultList;
                case CredentialsManagerService.AccessLevel.User:
                    resultList.Add(Position.PositionType.Driver);
                    resultList.Add(Position.PositionType.Conductor);
                    return resultList;
            }
            Console.WriteLine("PositionBuilder Error: resultList is empty, should not happen");
            return resultList;
        }
    }

    public struct UserDataKeys
    {
        public static string kUsername = "username";
        public static string kPassword = "password";
        public static string kAccessLevel = "accesslevel";
    }
}
