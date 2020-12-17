using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    using Networking.MultipleDependable;
    class DeleteFittingModel : BaseModel
    {
        private List<Fitting> allFittings;
        private Fitting selectedFitting;
        private bool wasFittingSelected = false;
        public void load() {
            allFittings = FittingNetworkProxy.GetAll();
        }

        public bool GetFittingSelectionStatus()
        {
            return wasFittingSelected;
        }

        public List<string> GetFittingFormattedIds()
        {
            List<string> formattedFittingIds = new List<string>();
            foreach(Fitting fitting in allFittings)
            {
                formattedFittingIds.Add(fitting.id.ToString());
            }
            return formattedFittingIds;
        }
        public string GetDescriptionForSelectedId(string id)
        {
            int numeralId = Convert.ToInt32(id);
            foreach (Fitting fitting in allFittings)
            {
                if (numeralId == fitting.id)
                {
                    selectedFitting = fitting;
                    wasFittingSelected = true;
                    string resultString = "";
                    resultString += $"Fitting with ID ({fitting.id})\n";
                    resultString += $"Fitting comment ({fitting.comment})\n";
                    resultString += $"Booking ID ({fitting.booking.id})\n";
                    resultString += $"Booking Creation Date: {fitting.booking.creationDate.ToString()}\n";
                    resultString += $"Booking Issue Date: {fitting.booking.issueDate.ToString()}\n";
                    resultString += $"Booking Total Sum: {fitting.booking.bookingSum}\n";
                    resultString += $"Is Marked: {fitting.booking.isMarked.ToString()}\n";
                    resultString += $"Model Name: {fitting.booking.model.name}\n";
                    resultString += $"Fabric Name: {fitting.booking.fabric.name}\n";
                    resultString += $"Cutter Name: fitting.{fitting.booking.cutter.fullName}\n";
                    resultString += $"Cutter Number of Orders: {fitting.booking.cutter.numberOfOrders}\n";
                    return resultString;
                }
            }
            return $"ERROR: Cannot load Fitting with ID ({id})";
        }

        public void DeleteObject()
        {
            FittingNetworkProxy.Delete(selectedFitting.id);
        }
    }
}
