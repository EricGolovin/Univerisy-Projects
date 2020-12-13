using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CourseWork_Atelie.Networking.MultipleDependable
{
    class RecommendationNetworkProxy
    {
        private static readonly Shared.SQLDatabaseConnetion connection = Shared.SQLDatabaseConnetion.instance;

        // Is unnecessary method (to remove?)
        public static List<Recommendation> Get(string request)
        {
            List<Recommendation> resultList = new List<Recommendation>();
            try
            {
                SqlDataReader reader = connection.Get(request);
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
            return resultList;
        }
        public static void Add(string request)
        {
            connection.Insert(request);
        }

        private static Independent.Model getModelById(int id)
        {
            string request = String.Format(Shared.GetRequestConsts.getModelByIdRequest, id);
            List<Independent.Model> newModels = Independent.ModelNetworkProxy.Get(request);
            return newModels.First();
        }

        private static SingleDependable.Fabric getFabricById(int id)
        {
            string request = String.Format(Shared.GetRequestConsts.getFabricByIdRequest, id);
            List<SingleDependable.Fabric> newFabrics = SingleDependable.FabricNetworkProxy.Get(request);
            return newFabrics.First();
        }
    }
    class Recommendation
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
