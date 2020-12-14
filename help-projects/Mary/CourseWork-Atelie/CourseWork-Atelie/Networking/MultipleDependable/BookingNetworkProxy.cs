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
        private static readonly Shared.SQLDatabaseConnetion connection = Shared.SQLDatabaseConnetion.instance;
        public static List<Booking> Get(string request)
        {
            List<Booking> resultList = new List<Booking>();
            try
            {
                SqlDataReader reader = connection.Get(request);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string creationDate = Convert.ToString(reader.GetValue(1));
                    string issueDate = Convert.ToString(reader.GetValue(2));
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
        public static void Add(string request)
        {
            connection.Insert(request);
        }

        private static Independent.Cutter getCutterById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.getCutterByIdRequest, id);
            List<Independent.Cutter> newCutters = Independent.CutterNetworkProxy.Get(request);
            return newCutters.First();
        }

        private static Independent.Client getClientById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.getClientByIdRequest, id);
            List<Independent.Client> newClients = Independent.ClientNetworkProxy.Get(request);
            return newClients.First();
        }

        private static Independent.Model getModelById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.getModelByIdRequest, id);
            List<Independent.Model> newModels = Independent.ModelNetworkProxy.Get(request);
            return newModels.First();
        }

        private static SingleDependable.Fabric getFabricById(int id)
        {
            string request = String.Format(Shared.RequestConsts.Get.getFabricByIdRequest, id);
            List<SingleDependable.Fabric> newFabrics = SingleDependable.FabricNetworkProxy.Get(request);
            return newFabrics.First();
        }
    }

    class Booking
    {
        public int id;
        public string creationDate;
        public Mark isMarked;
        public string issueDate;
        public double bookingSum;
        public readonly Independent.Cutter cutter;
        public readonly Independent.Client client;
        public readonly Independent.Model model;
        public readonly SingleDependable.Fabric fabric;

        public Booking(int id, string creationDate, Mark isMarked, string issueDate, double bookingSum, 
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

        public string toString()
        {
            return value ? "yes" : "no";
        }
    }
}
