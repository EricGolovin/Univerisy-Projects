using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    partial class AnalyticsFormModel : BaseModel
    {
        public void load() { }

        public string getFormattedClientOrdersNumber()
        {
            List<Networking.Independent.Client> clients = Networking.Independent.ClientNetworkProxy.GetAll();
            List<Networking.MultipleDependable.Booking> bookings = Networking.MultipleDependable.BookingNetworkProxy.GetAll();
            string resultString = "Number of orders for each client:\r";
            resultString += $"{Consts.lineBraker}\r";
            foreach (Networking.Independent.Client client in clients)
            {
                int resultNumOfOrders = 0;
                foreach (Networking.MultipleDependable.Booking booking in bookings)
                {
                    if (booking.client.id == client.id)
                    {
                        resultNumOfOrders += 1;
                    }
                }
                if (resultNumOfOrders > 0)
                {
                    resultString += $"{client.fullName}: ";
                    resultString += $"orders = {resultNumOfOrders}\r";
                    resultString += $"{Consts.lineBraker}\r";
                }
            }
            return resultString;
        }

        public string getFormattedCutterOrdersNumber()
        {
            List<Networking.Independent.Cutter> cutters = Networking.Independent.CutterNetworkProxy.GetAll();
            List<Networking.MultipleDependable.Booking> bookings = Networking.MultipleDependable.BookingNetworkProxy.GetAll();
            string resultString = "Number of orders for each cutter:\r";
            resultString += $"{Consts.lineBraker}\r";
            foreach (Networking.Independent.Cutter cutter in cutters)
            {
                int resultNumOfOrders = 0;
                foreach (Networking.MultipleDependable.Booking booking in bookings)
                {
                    if (booking.cutter.id == cutter.id)
                    {
                        resultNumOfOrders += 1;
                    }
                }
                if (resultNumOfOrders > 0)
                {
                    resultString += $"{cutter.fullName}: ";
                    resultString += $"orders = {resultNumOfOrders}\r";
                    resultString += $"{Consts.lineBraker}\r";
                }
            }
            return resultString;
        }

        public string getFormattedCutterAvailability()
        {
            List<Networking.Independent.Cutter> cutters = Networking.Independent.CutterNetworkProxy.GetAll();
            List<Networking.MultipleDependable.Booking> bookings = Networking.MultipleDependable.BookingNetworkProxy.GetAll();
            string resultString = "Cutters Availabilities:\r";
            resultString += $"{Consts.lineBraker}\r";
            foreach (Networking.Independent.Cutter cutter in cutters)
            {
                int resultNumOfOrders = 0;
                foreach (Networking.MultipleDependable.Booking booking in bookings)
                {
                    if (booking.cutter.id == cutter.id)
                    {
                        resultNumOfOrders += 1;
                    }
                }
                resultString += $"{cutter.fullName}: ";
                switch (resultNumOfOrders)
                {
                    case int number when (number >= 5):
                        resultString += "Cannot accept order\r";
                        break;
                    case int number when (number >= 4):
                        resultString += "Free for one order\r";
                        break;
                    case int number when (number >= 1):
                        resultString += "Ready to take order\r";
                        break;
                    default:
                        resultString += "Free\r";
                        break;
                }
                resultString += $"{Consts.lineBraker}\r";
            }
            return resultString;
        }

        public string getFormattedManufacturerPopularity()
        {
            List<Networking.SingleDependable.Fabric> fabrics = Networking.SingleDependable.FabricNetworkProxy.GetAll();
            List<Networking.Independent.Manufacturer> manufacturers = Networking.Independent.ManufacturerNetworkProxy.GetAll();
            List<Popularity<Networking.Independent.Manufacturer>> fabricalManufacturers = new List<Popularity<Networking.Independent.Manufacturer>>();

            foreach (Networking.Independent.Manufacturer manufacturer in manufacturers)
            {
                Popularity<Networking.Independent.Manufacturer> fabricalManufacturer = new Popularity<Networking.Independent.Manufacturer>(manufacturer);
                foreach (Networking.SingleDependable.Fabric fabric in fabrics)
                {
                    if (fabric.manufacturer.id == manufacturer.id)
                    {
                        fabricalManufacturer.priorityCounter += 1;
                    }
                }
                fabricalManufacturers.Add(fabricalManufacturer);
            }
            fabricalManufacturers.Sort();

            string resultString = "Manufacturer Popularity:\r";
            resultString += $"{Consts.lineBraker}\r";
            foreach (Popularity<Networking.Independent.Manufacturer> fabricalManufacturer in fabricalManufacturers)
            {
                resultString += $"{fabricalManufacturer.popularityObject.firmName}: ";
                resultString += $"popularity = {fabricalManufacturer.priorityCounter}\r";
                resultString += $"{Consts.lineBraker}\r";
            }
            return resultString;
        }

        public string getFormattedFabricPopularity()
        {
            List<Networking.SingleDependable.Fabric> fabrics = Networking.SingleDependable.FabricNetworkProxy.GetAll();
            List<Networking.MultipleDependable.Booking> bookings = Networking.MultipleDependable.BookingNetworkProxy.GetAll();
            List<Popularity<Networking.SingleDependable.Fabric>> fabricalPopularities = new List<Popularity<Networking.SingleDependable.Fabric>>();

            foreach (Networking.SingleDependable.Fabric fabric in fabrics)
            {
                Popularity<Networking.SingleDependable.Fabric> fabricalPopularity = new Popularity<Networking.SingleDependable.Fabric>(fabric);
                foreach (Networking.MultipleDependable.Booking booking in bookings)
                {
                    if (booking.fabric.id == fabric.id)
                    {
                        fabricalPopularity.priorityCounter += 1;
                    }
                }
                fabricalPopularities.Add(fabricalPopularity);
            }
            fabricalPopularities.Sort();

            string resultString = "Fabric Popularity:\r";
            resultString += $"{Consts.lineBraker}\r";
            foreach (Popularity<Networking.SingleDependable.Fabric> fabricalPopularity in fabricalPopularities)
            {
                if (fabricalPopularity.priorityCounter > 0)
                {
                    resultString += $"{fabricalPopularity.popularityObject.name}: ";
                    resultString += $"popularity = {fabricalPopularity.priorityCounter}\r";
                    resultString += $"{Consts.lineBraker}\r";
                }

            }
            return resultString;
        }

        public string getFormattedModelPopularity()
        {
            List<Networking.Independent.Model> models = Networking.Independent.ModelNetworkProxy.GetAll();
            List<Networking.MultipleDependable.Booking> bookings = Networking.MultipleDependable.BookingNetworkProxy.GetAll();
            List<Popularity<Networking.Independent.Model>> modelPopularities = new List<Popularity<Networking.Independent.Model>>();

            foreach (Networking.Independent.Model model in models)
            {
                Popularity<Networking.Independent.Model> modelPopularity = new Popularity<Networking.Independent.Model>(model);
                foreach (Networking.MultipleDependable.Booking booking in bookings)
                {
                    if (booking.model.id == model.id)
                    {
                        modelPopularity.priorityCounter += 1;
                    }
                }
                modelPopularities.Add(modelPopularity);
            }
            modelPopularities.Sort();

            string resultString = "Model Popularity:\r";
            resultString += $"{Consts.lineBraker}\r";
            foreach (Popularity<Networking.Independent.Model> modelPopularity in modelPopularities)
            {
                if (modelPopularity.priorityCounter > 0)
                {
                    resultString += $"{modelPopularity.popularityObject.name}: ";
                    resultString += $"popularity = {modelPopularity.priorityCounter}\r";
                    resultString += $"{Consts.lineBraker}\r";
                }
            }
            return resultString;
        }

        public string getFormattedBookingNumber(DateTime startTime, DateTime endTime)
        {
            List<Networking.MultipleDependable.Booking> bookings = Networking.MultipleDependable.BookingNetworkProxy.GetAll();
            List<Networking.MultipleDependable.Booking> resultBookings = new List<Networking.MultipleDependable.Booking>();
            foreach(Networking.MultipleDependable.Booking booking in bookings)
            {
                if (booking.creationDate > startTime && booking.creationDate < endTime)
                {
                    resultBookings.Add(booking);
                }
            }

            return $"{resultBookings.Count} Bookings created \rfrom {startTime.ToString("dd/MM/yyyy")} \rto {endTime.ToString("dd/MM/yyyy")}";
        }

        public string getFormattedOrdersSum(DateTime startTime, DateTime endTime)
        {
            List<Networking.MultipleDependable.Booking> bookings = Networking.MultipleDependable.BookingNetworkProxy.GetAll();
            double resultSum = 0.0;
            foreach (Networking.MultipleDependable.Booking booking in bookings)
            {
                if (booking.creationDate > startTime && booking.creationDate < endTime)
                {
                    resultSum += booking.bookingSum;
                }
            }

            return $"{resultSum} Orders Sum \rfrom {startTime.ToString("dd/MM/yyyy")} \rto {endTime.ToString("dd/MM/yyyy")}";
        }
    }

    partial class AnalyticsFormModel
    {
        struct Consts
        {
            public static string lineBraker = "----------------------";
        }

        class Popularity<T> : IComparable
        {
            public T popularityObject;
            public int priorityCounter = 0;
            public Popularity(T popularityObject)
            {
                this.popularityObject = popularityObject;
            }

            public int CompareTo(object obj)
            {
                Popularity<T> popularity = obj as Popularity<T>;
                if (popularity.priorityCounter > priorityCounter)
                {
                    return 1;
                } else if (popularity.priorityCounter < priorityCounter)
                {
                    return -1;
                } else
                {
                    return 0;
                }
            }
        }
    }
}
