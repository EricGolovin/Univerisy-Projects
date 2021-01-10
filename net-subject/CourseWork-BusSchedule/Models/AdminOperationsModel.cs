using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork_BusSchedule.Networking;
using CourseWork_BusSchedule.Networking.Models;

namespace CourseWork_BusSchedule.Models
{
    class AdminOperationsModel : BaseModel
    {
        private struct Consts
        {
            public static string lineBreaker = "\r-----------------------\r";
        }

        public readonly List<string> allModels = RequestConsts.Get.allClassNames;
        private CredentialsInfo currentCredentialsInfo = new CredentialsInfo();
        private string currentSelectedModel;

        public AdminOperationsModel()
        {
            currentSelectedModel = RequestConsts.Get.allClassNames.First();
        }

        public override void Load() {
        }

        public string GetAdminName()
        {
            if (currentCredentialsInfo.id == -1)
            {
                return "";
            }
            return currentCredentialsInfo.person.name;
        }

        public string GetCurrentSelectedModelName()
        {
            return currentSelectedModel;
        }
        public void SetCurrentSelectedModelName(string newModel)
        {
            currentSelectedModel = newModel;
        }

        public void SetCredentialsInfo(CredentialsInfo credentialsInfo)
        {
            this.currentCredentialsInfo = credentialsInfo;
        }

        public string GetDataForSelectedModel()
        {
            string resultString = "";
            if (currentSelectedModel == RequestConsts.Get.Bus.className)
            {
                foreach (Bus bus in BusProxy.GetAll())
                {
                    resultString += bus.GetDescription();
                    resultString += Consts.lineBreaker;
                }
            }
            else if (currentSelectedModel == RequestConsts.Get.Person.className)
            {
                foreach (Person person in PersonInfoProxy.GetAll())
                {
                    resultString += person.GetDescription();
                    resultString += Consts.lineBreaker;
                }
            }
            else if (currentSelectedModel == RequestConsts.Get.Itinerary.className)
            {
                foreach (Itinerary itinerary in ItineraryProxy.GetAll())
                {
                    resultString += itinerary.GetDescription();
                    resultString += Consts.lineBreaker;
                }
            }
            else if (currentSelectedModel == RequestConsts.Get.CredentialsInfo.className)
            {
                foreach (CredentialsInfo credentialsInfo in CredentialsInfoProxy.GetAll())
                {
                    resultString += credentialsInfo.GetDescription();
                    resultString += Consts.lineBreaker;
                }
            }
            else if (currentSelectedModel == RequestConsts.Get.RouteSheet.className)
            {
                foreach (RouteSheet routeSheet in RouteSheetProxy.GetAll())
                {
                    resultString += routeSheet.GetDescription();
                    resultString += Consts.lineBreaker;
                }
            }
            return resultString;
        }
    }
}
