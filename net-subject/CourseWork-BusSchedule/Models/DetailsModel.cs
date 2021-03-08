using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork_BusSchedule.Networking.Models;

namespace CourseWork_BusSchedule.Models
{
    class DetailsModel : BaseModel
    {
        private CredentialsInfo currentCredentialsInfo = new CredentialsInfo();
        private List<RouteSheet> routeSheets = new List<RouteSheet>();

        public override void Load()
        {
            routeSheets = RouteSheetProxy.GetAll();
        }

        public void SetCredentialsInfo(CredentialsInfo credentialsInfo)
        {
            this.currentCredentialsInfo = credentialsInfo;
        }

        public string GetUserPositionAndName()
        {
            if (currentCredentialsInfo.id == -1)
            {
                return "";
            }
            return $"{currentCredentialsInfo.position.GetTypeDescription()} {currentCredentialsInfo.person.name}";
        }

        public string GetItineraryForDate(DateTime selectedDate)
        {
            foreach(RouteSheet sheet in routeSheets)
            {
                if (sheet.credentialsInfo.id == currentCredentialsInfo.id && sheet.routeDate.Date == selectedDate.Date)
                {
                    return sheet.itinerary.GetDescription();
                }
            }
            return "No route sheet for selected date";
        }
    }
}
