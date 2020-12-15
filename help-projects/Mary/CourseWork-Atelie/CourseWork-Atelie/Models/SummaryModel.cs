using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Atelie.Models
{
    class SummaryModel : BaseModel
    {
        public Networking.MultipleDependable.Recommendation configuredRecommendation;
        public Networking.Independent.Client configuredClient;
        public void load() { }

        public string getBookingSum()
        {
            return $"{configuredRecommendation.model.price + configuredRecommendation.fabric.price * configuredRecommendation.model.consumption}";
        }

        public string getCurrentDate()
        {
            return DateTime.Now.ToString("MM/dd/yyyy");
        }

        public string getModelPictureUrl()
        {
            return configuredRecommendation.model.photoLink;
        }

        public string getFabricPictureUrl()
        {
            return configuredRecommendation.fabric.photoLink;
        }

        public void sendBooking()
        {
            Networking.Independent.Cutter lowestCutter = loadLowestCutter();
            Networking.MultipleDependable.BookingNetworkProxy.Add(getBookingNumeralSum(), lowestCutter.id, configuredClient.id, configuredRecommendation.model.id, configuredRecommendation.fabric.id);
            Networking.Independent.CutterNetworkProxy.UpdateNumberOfOders(lowestCutter.numberOfOrders + 1, lowestCutter.id);
        }

        private double getBookingNumeralSum()
        {
            return configuredRecommendation.model.price + configuredRecommendation.fabric.price * configuredRecommendation.model.consumption;
        }

        private Networking.Independent.Cutter loadLowestCutter()
        {
            List<Networking.Independent.Cutter> cutters = Networking.Independent.CutterNetworkProxy.GetAll();
            Networking.Independent.Cutter lowestCutter = cutters[0];
            cutters.RemoveAt(0);
            foreach (Networking.Independent.Cutter cutter in cutters)
            {
                if (lowestCutter.numberOfOrders > cutter.numberOfOrders)
                {
                    lowestCutter = cutter;
                }
            }
            return lowestCutter;
        }
    }
}
