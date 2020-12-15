using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CourseWork_Atelie.Networking.MultipleDependable
{
    class FittingNetworkProxy
    {
        public static List<Fitting> Get(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            List<Fitting> resultList = new List<Fitting>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string comment = Convert.ToString(reader.GetValue(1));
                    int bookingId = Convert.ToInt32(reader.GetValue(2));

                    MultipleDependable.Booking newBooking = getBookingById(bookingId);

                    Fitting newObject = new Fitting(id, comment, newBooking);
                    resultList.Add(newObject);
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("ModelList is Empty");
            }
            connection.closeConnection();
            return resultList;
        }
        public static void Add(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            connection.Insert(request);
        }

        private static MultipleDependable.Booking getBookingById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.Booking.getByIdRequest, id);
            List<MultipleDependable.Booking> newBookings = MultipleDependable.BookingNetworkProxy.Get(request);
            return newBookings.First();
        }
    }

    class Fitting
    {
        public int id;
        public string comment;
        public readonly MultipleDependable.Booking booking;

        public Fitting(int id, string comment, MultipleDependable.Booking booking)
        {
            this.id = id;
            this.comment = comment;
            this.booking = booking;
        }

        public int getBookingId()
        {
            return booking.id;
        }
    }
}
