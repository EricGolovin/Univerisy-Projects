using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CourseWork_Atelie.Networking.MultipleDependable
{
    public class RecommendationNetworkProxy
    {
        private static readonly Shared.SQLDatabaseConnetion connection = Shared.SQLDatabaseConnetion.instance;

        // Is unnecessary method (to remove?)
        public static List<Recommendation> Get(string request, Independent.Model model, SingleDependable.Fabric fabric)
        {
            List<Recommendation> resultList = new List<Recommendation>();
            try
            {
                SqlDataReader reader = connection.Get(String.Format(request, model.id, fabric.id));
                while (reader.Read())
                {
                    int modelId = Convert.ToInt32(reader.GetValue(0));
                    int fabricId = Convert.ToInt32(reader.GetValue(1));

                    Independent.Model newModel = getModelById(modelId);
                    SingleDependable.Fabric newFabric = getFabricById(fabricId);

                    Recommendation newObject = new Recommendation(newModel, newFabric);
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
        public static void Add(Networking.Independent.Model model, Networking.SingleDependable.Fabric fabric) 
        {
            connection.Insert(String.Format(Networking.Shared.RequestConsts.Put.Dependable.putRecomendationRequest, model.id, fabric.id));
        }

        public static List<Recommendation> GetAll()
        {
            List<Recommendation> resultList = new List<Recommendation>();
            try
            {
                SqlDataReader reader = connection.Get(Networking.Shared.RequestConsts.Get.Recommendation.getAllRequest);
                while (reader.Read())
                {
                    int modelId = Convert.ToInt32(reader.GetValue(0));
                    int fabricId = Convert.ToInt32(reader.GetValue(1));

                    Independent.Model newModel = getModelById(modelId);
                    SingleDependable.Fabric newFabric = getFabricById(fabricId);

                    Recommendation newObject = new Recommendation(newModel, newFabric);
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
    public class Recommendation
    {
        public readonly Independent.Model model;
        public readonly SingleDependable.Fabric fabric;

        public Recommendation(Independent.Model model, SingleDependable.Fabric fabric)
        {
            this.model = model;
            this.fabric = fabric;
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
}
