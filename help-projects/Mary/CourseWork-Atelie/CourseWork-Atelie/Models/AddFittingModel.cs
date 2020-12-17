using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    using Networking.MultipleDependable;
    class AddFittingModel : BaseModel
    {
        private string configuredComment = "";
        private Booking selectedBooking;
        private List<Booking> allBookings;
        private List<Fitting> allFittings;
        private bool wasBookingSelected = false;
        public void load() {
            allBookings = BookingNetworkProxy.GetAll();
            allFittings = FittingNetworkProxy.GetAll();
            RemoveBookingDuplicates();
        }

        public bool GetBookingSelectionStatus()
        {
            return wasBookingSelected;
        }

        public List<string> GetBookingFormattedIds()
        {
            List<string> formattedBookingIds = new List<string>();
            foreach(Booking booking in allBookings)
            {
                formattedBookingIds.Add(booking.id.ToString());
            }
            return formattedBookingIds;
        }

        public string GetDescriptionForSelectedId(string id)
        {
            int numeralId = Convert.ToInt32(id);
            foreach(Booking booking in allBookings)
            {
                if (numeralId == booking.id)
                {
                    selectedBooking = booking;
                    wasBookingSelected = true;
                    string resultString = "";
                    resultString += $"Booking with ID ({booking.id})\n";
                    resultString += $"Booking Creation Date: {booking.creationDate.ToString()}\n";
                    resultString += $"Booking Issue Date: {booking.issueDate.ToString()}\n";
                    resultString += $"Booking Total Sum: {booking.bookingSum}\n";
                    resultString += $"Is Marked: {booking.isMarked.ToString()}\n";
                    resultString += $"Model Name: {booking.model.name}\n";
                    resultString += $"Fabric Name: {booking.fabric.name}\n";
                    resultString += $"Cutter Name: {booking.cutter.fullName}\n";
                    resultString += $"Cutter Number of Orders: {booking.cutter.numberOfOrders}\n";
                    return resultString;
                } 
            }
            return $"ERROR: Cannot load Booking with ID ({id})";
        }

        public void SetComment(string newComment)
        {
            configuredComment = newComment;
        }

        public void SendObject()
        {
            FittingNetworkProxy.Add(selectedBooking.id, configuredComment);
            foreach (Fitting fitting in FittingNetworkProxy.GetAll())
            {
                Console.WriteLine("------------------------");
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
                Console.WriteLine(resultString);
                Console.WriteLine("------------------------");
            }
        }

        private void RemoveBookingDuplicates()
        {
            List<Booking> newBookingList = new List<Booking>();

            foreach(Booking booking in allBookings)
            {
                int popularityCounter = 0;
                foreach (Fitting fitting in allFittings)
                {
                    if (fitting.booking.id == booking.id)
                    {
                        popularityCounter += 1;
                    }
                }
                if (popularityCounter < 3)
                {
                    newBookingList.Add(booking);
                }
            }

            allBookings = newBookingList;
        }
    }
}
