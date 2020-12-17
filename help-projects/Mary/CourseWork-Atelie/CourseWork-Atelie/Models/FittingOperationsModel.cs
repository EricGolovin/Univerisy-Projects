using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    using Networking.MultipleDependable;
    partial class FittingOperationsModel : BaseModel
    {
        public void load() { }

        public string GetAllFormattedFittings()
        {
            List<Fitting> allFittings = FittingNetworkProxy.GetAll();
            string resultString = "";
            foreach(Fitting fitting in allFittings)
            {
                resultString += $"{Consts.lineBraker}\n";
                resultString += $"ID: {fitting.id}; Booking ID: {fitting.booking.id}; Comment: {fitting.comment}\n";
                resultString += $"{Consts.lineBraker}\n";
            }
            return resultString;
        }
    }

    partial class FittingOperationsModel
    {
        struct Consts
        {
            public static string lineBraker = "------------------";
        }
    }
}
