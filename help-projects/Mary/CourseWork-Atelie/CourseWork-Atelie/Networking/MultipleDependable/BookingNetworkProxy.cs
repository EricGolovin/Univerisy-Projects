using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ExtensionMethods;

namespace CourseWork_Atelie.Networking.MultipleDependable
{
    class BookingNetworkProxy
    {
        public static List<Booking> Get(string request)
        {
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            List<Booking> resultList = new List<Booking>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    DateTime creationDate = DateTime.Parse(Convert.ToString(reader.GetValue(1)));
                    DateTime issueDate = DateTime.Parse(Convert.ToString(reader.GetValue(2)));
                    Mark isMarked = new Mark(Convert.ToString(reader.GetValue(3)));
                    double bookingSum = Convert.ToDouble(reader.GetValue(4));
                    int cutterId = Convert.ToInt32(reader.GetValue(5));
                    int clientId = Convert.ToInt32(reader.GetValue(6));
                    int modelId = Convert.ToInt32(reader.GetValue(7));
                    int fabricId = Convert.ToInt32(reader.GetValue(8));

                    Independent.Cutter newCutter = getCutterById(cutterId);
                    Independent.Client newClient = getClientById(clientId);
                    Independent.Model newModel = getModelById(modelId);
                    SingleDependable.Fabric newFabric = getFabricById(fabricId);

                    Booking newObject = new Booking(id, creationDate, isMarked, issueDate, bookingSum, newCutter, newClient, newModel, newFabric);
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

        public static List<Booking> GetAll()
        {
            return Get(Shared.RequestConsts.Get.Booking.getAllRequest);
        }
        public static void Add(double bookingSum, int cutterId, int clientId, int modelId, int fabricId)
        {
            string issueDate = DateTime.Today.AddDays(7).ToString("MM/dd/yyyy");
            Shared.SQLDatabaseConnetion connection = new Shared.SQLDatabaseConnetion();
            string bookingInsertRequest = String.Format(Shared.RequestConsts.Put.Dependable.putBookingRequest, 
                DateTime.Today.ToString("MM/dd/yyyy"),
                issueDate,
                new Mark(false).ToString(),
                bookingSum,
                cutterId,
                clientId,
                modelId,
                fabricId);
            connection.Insert(bookingInsertRequest);
        }

        private static Independent.Cutter getCutterById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.Cutter.getByIdRequest, id);
            List<Independent.Cutter> newCutters = Independent.CutterNetworkProxy.Get(request);
            return newCutters.First();
        }

        private static Independent.Client getClientById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.Client.getByIRequest, id);
            List<Independent.Client> newClients = Independent.ClientNetworkProxy.Get(request);
            return newClients.First();
        }

        private static Independent.Model getModelById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.Model.getByIdRequest, id);
            List<Independent.Model> newModels = Independent.ModelNetworkProxy.Get(request);
            return newModels.First();
        }

        private static SingleDependable.Fabric getFabricById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.Fabric.getByIdRequest, id);
            List<SingleDependable.Fabric> newFabrics = SingleDependable.FabricNetworkProxy.Get(request);
            return newFabrics.First();
        }
    }

    class Booking
    {
        public int id;
        public DateTime creationDate;
        public Mark isMarked;
        public DateTime issueDate;
        public double bookingSum;
        public readonly Independent.Cutter cutter;
        public readonly Independent.Client client;
        public readonly Independent.Model model;
        public readonly SingleDependable.Fabric fabric;

        public Booking(int id, DateTime creationDate, Mark isMarked, DateTime issueDate, double bookingSum, 
            Independent.Cutter cutter,
            Independent.Client client, 
            Independent.Model model,
            SingleDependable.Fabric fabric)
        {
            this.id = id;
            this.creationDate = creationDate;
            this.isMarked = isMarked;
            this.issueDate = issueDate;
            this.bookingSum = bookingSum;
            this.cutter = cutter;
            this.client = client;
            this.model = model;
            this.fabric = fabric;
        }

        public int getCutterId()
        {
            return client.id;
        }

        public int getClientId()
        {
            return client.id;
        }

        public int getModelId()
        {
            return model.id;
        }

        public int getFabricId()
        {
            return fabric.id;
        }
    }

    class Mark
    {
        private bool value;
        public Mark(string mark)
        {
            if (mark.RemoveWhitespace() == "yes")
            {
                this.value = true;
            } else
            {
                this.value = false;
            }
        }

        public Mark(bool mark)
        {
            this.value = mark;
        }

        public string ToString()
        {
            return value ? "yes" : "no";
        }
    }
}
